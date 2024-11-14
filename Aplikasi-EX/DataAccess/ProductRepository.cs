using Aplikasi_EX.Model;
using Npgsql;
using System;
using System.Collections;
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
    }
}