using Aplikasi_EX.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.DataAccess
{
    public class OrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository()
        {
            _connectionString = ConfigurationHelper.GetConnectionString("AzureDbConnection");
        }
        public async Task<List<Order>> getSellerOrderAsync(int sellerid)
        {
            var orders = new List<Order>();
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM getsellerorder(@Sellerid)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Sellerid", sellerid);
                    using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            orders.Add(new Order
                            {
                                OrderID = reader.GetInt32(reader.GetOrdinal("orderid")),
                                Name = reader.GetString(reader.GetOrdinal("product_name")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                                Status = reader.GetString(reader.GetOrdinal("status")),
                                LastUpdated = reader.GetDateTime(reader.GetOrdinal("last_updated")),
                            });
                        }
                    }
                }
            }
            return orders;
        }
        public async Task<List<Order>> getBuyerOrderAsync(int buyerid)
        {
            var orders = new List<Order>();
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM getbuyerorder(@Buyerid)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Buyerid", buyerid);
                    using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            orders.Add(new Order
                            {
                                OrderID = reader.GetInt32(reader.GetOrdinal("orderid")),
                                Name = reader.GetString(reader.GetOrdinal("product_name")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                                Status = reader.GetString(reader.GetOrdinal("status")),
                                LastUpdated = reader.GetDateTime(reader.GetOrdinal("last_updated")),
                            });
                        }
                    }
                }
            }
            return orders;
        }
    }
}
