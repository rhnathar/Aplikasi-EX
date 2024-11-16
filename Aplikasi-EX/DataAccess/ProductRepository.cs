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
        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            var products = new List<Product>();
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM getproductbycategory(@category)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@category", category);
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
                                    SellerID = reader.GetInt32(6),
                                    Quantity = reader.GetInt32(7),
                                    Condition = reader.GetString(8),
                                    Category = reader.GetString(9)
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
<<<<<<< HEAD

        public async Task UpdateProductAsync(Product product)
        {
=======
        public async Task<List<Product>> GetProductsBySearchAsync(string search)
        {
            var products = new List<Product>();
>>>>>>> 3bafb097e69546b5186dcf437f117526933e3530
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
<<<<<<< HEAD
                    string query = "SELECT updateproduct(@productID, @product_name, @price, @date_added, @description, @quantity, @condition, @category, @product_image)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@productID", product.ProductID);
                        cmd.Parameters.AddWithValue("@product_name", product.ProductName);
                        cmd.Parameters.AddWithValue("@price", product.Price);
                        cmd.Parameters.AddWithValue("@date_added", product.DateAdded);
                        cmd.Parameters.AddWithValue("@description", product.Description);
                        cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                        cmd.Parameters.AddWithValue("@condition", product.Condition);
                        cmd.Parameters.AddWithValue("@category", product.Category);
                        cmd.Parameters.AddWithValue("@product_image", product.ImagePath);
                        await cmd.ExecuteNonQueryAsync();
=======
                    string query = "SELECT * FROM getproductbysearch(@search)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", search);
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
                                    SellerID = reader.GetInt32(6),
                                    Quantity = reader.GetInt32(7),
                                    Condition = reader.GetString(8),
                                    Category = reader.GetString(9)
                                });
                            }
                        }
>>>>>>> 3bafb097e69546b5186dcf437f117526933e3530
                    }
                }
            }
            catch (Exception ex)
            {
<<<<<<< HEAD
                throw new Exception("Error during update product: " + ex.Message, ex);
            }
        }
        public async Task DeleteProductAsync(Product product)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT deleteproduct(@productID)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@productID", product.ProductID);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during product deletion: " + ex.Message, ex);
            }
        }

        public async Task GetProductByIdAsync(Product product)
        {
            try
            {
                using (var conn =new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT getproductbyid(@productID)";
                    using (var cmd = new NpgsqlCommand(query,conn))
                    {
                        cmd.Parameters.AddWithValue("@productID", product.ProductID);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during product getting: " + ex.Message, ex);
            }
        }

        internal async Task GetProductByIdAsync(int productID, int productID1)
        {
            throw new NotImplementedException();
=======
                throw new Exception("Error retrieving seller products: " + ex.Message, ex);
            }
            return products;
>>>>>>> 3bafb097e69546b5186dcf437f117526933e3530
        }
    }
}