using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public DateTime Date { get; set; }

        public void GetProductDetails(int productId)
        {
            // Logic to get product details
            Console.WriteLine($"Product ID: {productId}, Name: {ProductName}, Price: {Price}");
        }

        public bool AddProduct(int productId)
        {
            // Logic to add product
            Console.WriteLine($"Product {productId} added successfully.");
            return true;
        }

        public void UpdateProduct()
        {
            // Logic to update product details
            Console.WriteLine($"Product {ProductId} updated successfully.");
        }
    }

}
