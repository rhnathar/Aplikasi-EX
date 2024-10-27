using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Model
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminPassword { get; set; }

        public void ManageCustomer(int customerId)
        {
            // Logic to manage customer details
            Console.WriteLine($"Admin managing customer with ID: {customerId}");
        }

        public void ManageSeller(int sellerId)
        {
            // Logic to manage seller details
            Console.WriteLine($"Admin managing seller with ID: {sellerId}");
        }

        public void ManageProduct(int productId)
        {
            // Logic to manage product details
            Console.WriteLine($"Admin managing product with ID: {productId}");
        }
    }

}
