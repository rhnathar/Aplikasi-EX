using System.Collections.ObjectModel;
using Aplikasi_EX.Model;
using Aplikasi_EX.Utilities;
using Aplikasi_EX.View;
using System.Windows.Input;

namespace Aplikasi_EX.ViewModel
{
    class SellerProductVM : Utilities.ViewModelBase
    {
        public ICommand OpenAddProductCommand { get; }
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

        public SellerProductVM()
        {
            // Initialize or load products here with data that matches the bindings in the ProductCard
            Products = new ObservableCollection<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Rtx 3070 Ti",
                    Price = 5000000,
                    Description = "GPU yang sangat kuat dan terbukti tahan terhadap se...",
                    Quantity = 5,
                    Category = "Computer",
                    ImagePath = "/img/rtx.png"
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Rtx 3080",
                    Price = 7000000,
                    Description = "High-performance GPU for gaming and productivity",
                    Quantity = 3,
                    Category = "Computer",
                    ImagePath = "/img/rtx.png"
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "AMD Ryzen 9",
                    Price = 6000000,
                    Description = "High-performance processor for demanding tasks",
                    Quantity = 8,
                    Category = "Computer",
                    ImagePath = "/img/rtx.png"
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Intel Core i9",
                    Price = 7500000,
                    Description = "Powerful CPU with high clock speed",
                    Quantity = 6,
                    Category = "Computer",
                    ImagePath = "/img/rtx.png"
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "Samsung SSD 1TB",
                    Price = 1500000,
                    Description = "High-speed SSD for faster data access",
                    Quantity = 15,
                    Category = "Storage",
                    ImagePath = "/img/rtx.png"
                },
            };

            
            // Initialize the command
            OpenAddProductCommand = new RelayCommand(OpenAddProduct);
        }

        void OpenAddProduct(object parameter)
        {
            // Create an instance of the popup window
            var addProductWindow = new AddProductPopUp();

            // Show the popup as a dialog
            addProductWindow.ShowDialog();
        }
    }
}

