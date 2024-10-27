using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Aplikasi_EX.Utilities;
using Aplikasi_EX.Model;
using Npgsql;

public class UserRepository
{
    private readonly string _connectionString;

    public UserRepository()
    {
        _connectionString = ConfigurationHelper.GetConnectionString("AzureDbConnection");
    }

    public List<User> GetUsers()
    {
        var users = new List<User>();
        using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM user_account";
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
}