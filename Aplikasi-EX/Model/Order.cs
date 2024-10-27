using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Status { get; set; }

        public void PlaceOrder()
        {
            // Logic to place an order
            Status = "Order Placed";
            Console.WriteLine("Order placed successfully.");
        }

        public void CancelOrder()
        {
            // Logic to cancel an order
            Status = "Order Cancelled";
            Console.WriteLine("Order cancelled successfully.");
        }

        public void GetOrderDetails()
        {
            // Logic to get order details
            Console.WriteLine($"Order ID: {OrderId}, Status: {Status}");
        }
    }

}
