using Aplikasi_EX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public MainViewModel()
        {
            Products = new ObservableCollection<Product>();
            LoadProducts();
        }

        private void LoadProducts()
        {
            // Logic to fetch products from the database and add them to Products collection
            // Example: Products.Add(new Product { ProductID = 1, ProductName = "RTX 3070 Ti", Price = 5000000 });
        }
    }
}
