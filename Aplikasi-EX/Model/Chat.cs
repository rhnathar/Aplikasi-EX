using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Model
{
    public class Chat
    {
        public int ChatId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public void PlaceOrder()
        {
            // Logic to chat for placing an order
            Console.WriteLine("Chat: Order placed via chat.");
        }

        public void CancelOrder()
        {
            // Logic to chat for cancelling an order
            Console.WriteLine("Chat: Order cancelled via chat.");
        }

        public void GetOrderDetails()
        {
            // Logic to chat for getting order details
            Console.WriteLine($"Chat: Order details retrieved via chat.");
        }
    }

}
