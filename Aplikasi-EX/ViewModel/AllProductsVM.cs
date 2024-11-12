using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Aplikasi_EX.Model;



namespace Aplikasi_EX.ViewModel
{
    class AllProductsVM : Utilities.ViewModelBase
    {

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public AllProductsVM()
        {
            // Initialize or load products here
            Products = new ObservableCollection<Product>
            {
                new Product { ProductID = 1, ProductName = "Rtx 3070 Ti", Price = 5000000, Description = "Powerful GPU", Quantity = 10, ImagePath = "/img/rtx.png" },
                new Product { ProductID = 2, ProductName = "Rtx 3080", Price = 7000000, Description = "High-performance GPU", Quantity = 5, ImagePath = "/img/rtx.png" },
                new Product { ProductID = 1, ProductName = "Rtx 3070 Ti", Price = 5000000, Description = "Powerful GPU", Quantity = 10, ImagePath = "/img/rtx.png" },
                new Product { ProductID = 2, ProductName = "Rtx 3080", Price = 7000000, Description = "High-performance GPU", Quantity = 5, ImagePath = "/img/rtx.png" },
                new Product { ProductID = 1, ProductName = "Rtx 3070 Ti", Price = 5000000, Description = "Powerful GPU", Quantity = 10, ImagePath = "/img/rtx.png" },
                new Product { ProductID = 2, ProductName = "Rtx 3080", Price = 7000000, Description = "High-performance GPU", Quantity = 5, ImagePath = "/img/rtx.png" },
                new Product { ProductID = 1, ProductName = "Rtx 3070 Ti", Price = 5000000, Description = "Powerful GPU", Quantity = 10, ImagePath = "/img/rtx.png" },
                new Product { ProductID = 2, ProductName = "Rtx 3080", Price = 7000000, Description = "High-performance GPU", Quantity = 5, ImagePath = "/img/rtx.png" },
                new Product { ProductID = 1, ProductName = "Rtx 3070 Ti", Price = 5000000, Description = "Powerful GPU", Quantity = 10, ImagePath = "/img/rtx.png" },
                new Product { ProductID = 2, ProductName = "Rtx 3080", Price = 7000000, Description = "High-performance GPU", Quantity = 5, ImagePath = "/img/rtx.png" },

                // Additional products
            };
        }
    }
}
