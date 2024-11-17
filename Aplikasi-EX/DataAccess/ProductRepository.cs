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
        public async Task<List<Product>> GetProductsBySearchAsync(string search)
        {
            var products = new List<Product>();
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
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
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving seller products: " + ex.Message, ex);
            }
            return products;
        }

        public async Task<Product> GetProductsByIDAsync(int productID)
        {
            var product = new Product();
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM getproductbyid(@productID)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@productID", productID);
                        using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                product = new Product
                                {
                                    ProductID = reader.GetInt32(0),
                                    ProductName = reader.GetString(1),
                                    Price = reader.GetInt32(2),
                                    DateAdded = reader.GetDateTime(3),
                                    Description = reader.GetString(4),
                                    SellerID = reader.GetInt32(5),
                                    Quantity = reader.GetInt32(6),
                                    Condition = reader.GetString(7),
                                    Category = reader.GetString(8),
                                    ImagePath = reader.GetString(9)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving seller products: " + ex.Message, ex);
            }
            return product;
        }

        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
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
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during update product: " + ex.Message, ex);
            }
        }

        public async Task BuyProductAsync(int ProductID, int Quantity, int BuyerID)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT buyproduct(@productID, @quantity, @buyerID)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@productID", ProductID);
                        cmd.Parameters.AddWithValue("@quantity",Quantity);
                        cmd.Parameters.AddWithValue("@buyerID", BuyerID);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during buy product: " + ex.Message, ex);
            }
        }
    }
}