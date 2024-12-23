﻿// DAL/Repositories/UserRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using Aplikasi_EX.Model;
using Aplikasi_EX.Utilities;
using System;

namespace Aplikasi_EX.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository()
        {
            _connectionString = ConfigurationHelper.GetConnectionString("AzureDbConnection");
        }

        public async Task RegisterAsync(User user)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT RegisterUser(@name, @address, @phone_number, @email, @password, @type)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", user.Name);
                        cmd.Parameters.AddWithValue("@address", user.Address);
                        cmd.Parameters.AddWithValue("@phone_number", user.PhoneNumber);
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@type", user.Type);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during registration: " + ex.Message, ex);
            }
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            User user = null;
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM LoginUser(@Email, @Password)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            user = new User
                            {
                                UserID = reader.GetInt32(reader.GetOrdinal("userID")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Address = reader.GetString(reader.GetOrdinal("address")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("phone_number")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                Type = reader.GetString(reader.GetOrdinal("type"))
                            };
                        }
                    }
                }
            }
            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = new List<User>();
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM user_account";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            users.Add(new User
                            {
                                UserID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                PhoneNumber = reader.GetString(3),
                                Email = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return users;
        }

        public async Task UpdateDataAccount(User user)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT updatedatauseraccount(@userID, @name, @address, @phone_number, @email, @password)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", user.UserID);
                        cmd.Parameters.AddWithValue("@name", user.Name);
                        cmd.Parameters.AddWithValue("@address", user.Address);
                        cmd.Parameters.AddWithValue("phone_number", user.PhoneNumber);
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("Password", user.Password);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during update data account: " + ex.Message, ex);
            }
        }
    }
}
