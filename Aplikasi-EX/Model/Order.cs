using System;

namespace Aplikasi_EX.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public int BuyerID { get; set; }
        public int SellerID { get; set; }

        // Additional properties for display purposes
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
