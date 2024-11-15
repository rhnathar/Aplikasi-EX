using Aplikasi_EX.Model;
using Npgsql;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.DataAccess
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository()
        {
            _connectionString = ConfigurationHelper.GetConnectionString("AzureDbConnection");
        }

        public async Task InsertProductAsync(Product product)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT from insert_product(@product_name, @price, @date_added, @description, @product_image, @sellerID, @quantity, @condition, @category)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@product_name", product.ProductName);
                        cmd.Parameters.AddWithValue("@price", product.Price);
                        cmd.Parameters.AddWithValue("@date_added", product.DateAdded);
                        cmd.Parameters.AddWithValue("@description", product.Description);
                        cmd.Parameters.AddWithValue("@product_image", product.ImagePath);
                        cmd.Parameters.AddWithValue("@sellerID", product.SellerID);
                        cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                        cmd.Parameters.AddWithValue("@condition", product.Condition);
                        cmd.Parameters.AddWithValue("@category", product.Category);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during registration: " + ex.Message, ex);
            }
        }
        public async Task<List<Product>> GetSellerProductsAsync(int sellerID)
        {
            var products = new List<Product>();
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM get_seller_products(@sellerID)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sellerID", sellerID);
                        using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                products.Add(new Product
                                {
                                    ProductID = reader.GetInt32(0),
                                    ProductName = reader.GetString(1),
                                    Price = reader.GetInt32(2),
                                    DateAdded = reader.GetDateTime(3),
                                    Description = reader.GetString(4),
                                    ImagePath = reader.GetString(5),
                                    Quantity = reader.GetInt32(6),
                                    Condition = reader.GetString(7),
                                    Category = reader.GetString(8)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving seller products: " + ex.Message, ex);
            }
            return products;
        }

    }
}