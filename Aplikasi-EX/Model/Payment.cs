using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public long Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }

        public void ProcessPayment()
        {
            // Logic to process payment
            PaymentStatus = "Payment Processed";
            Console.WriteLine("Payment processed successfully.");
        }

        public void GetPaymentDetails()
        {
            // Logic to get payment details
            Console.WriteLine($"Payment ID: {PaymentId}, Amount: {Amount}, Status: {PaymentStatus}");
        }
    }

}
