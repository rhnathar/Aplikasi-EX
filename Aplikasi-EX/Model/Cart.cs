using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Model
{
    public class Cart
    {
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public DateTime Date { get; set; }

        public void AddItem(int productId)
        {
            // Logic to add product to the cart
            Console.WriteLine($"Product {productId} added to the cart.");
        }

        public void RemoveItem(int productId)
        {
            // Logic to remove product from the cart
            Console.WriteLine($"Product {productId} removed from the cart.");
        }

        public void GetCartDetails()
        {
            // Logic to get cart details
            Console.WriteLine($"Cart ID: {CartId}, Product: {ProductName}, Price: {Price}, Date: {Date}");
        }

        public void Checkout()
        {
            // Logic to handle checkout
            Console.WriteLine("Cart checked out successfully.");
        }
    }

}
