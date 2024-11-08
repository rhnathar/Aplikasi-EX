using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_EX.Utilities;
using System.Collections.ObjectModel;
using Aplikasi_EX.Model;

namespace Aplikasi_EX.ViewModel
{
    class SellerOrderVM : Utilities.ViewModelBase
    {
        // Orders collection
        public ObservableCollection<Order> Orders { get; set; }

        // Constructor to initialize dummy data for orders
        public SellerOrderVM()
        {
            // Initialize dummy data for Orders
            Orders = new ObservableCollection<Order>
            {
                new Order
                {
                    OrderID = 101,
                    Name = "Smartphone Samsung Galaxy",
                    Quantity = 15,
                    Status = "Pending",
                    LastUpdated = DateTime.Now.AddDays(-1)
                },
                new Order
                {
                    OrderID = 102,
                    Name = "Laptop HP Pavilion",
                    Quantity = 7,
                    Status = "Shipped",
                    LastUpdated = DateTime.Now.AddDays(-3)
                },
                new Order
                {
                    OrderID = 103,
                    Name = "Wireless Headphones Sony",
                    Quantity = 20,
                    Status = "Delivered",
                    LastUpdated = DateTime.Now.AddDays(-5)
                },
                new Order
                {
                    OrderID = 104,
                    Name = "Monitor LG UltraWide",
                    Quantity = 10,
                    Status = "Pending",
                    LastUpdated = DateTime.Now.AddDays(-7)
                }
            };
        }
    }
}
