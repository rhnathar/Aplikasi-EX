using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aplikasi_EX.ViewModel
{
    public class DetailProductVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string _productName;
        private string _condition;
        private string _category;
        private int _stock;
        private string _location;
        private decimal _price;
        private string _description;
        private string _productImage;

        public string ProductName
        {
            get => _productName;
            set { _productName = value; OnPropertyChanged(nameof(ProductName)); }
        }

        public string Condition
        {
            get => _condition;
            set { _condition = value; OnPropertyChanged(nameof(Condition)); }
        }

        public string Category
        {
            get => _category;
            set { _category = value; OnPropertyChanged(nameof(Category)); }
        }

        public int Stock
        {
            get => _stock;
            set { _stock = value; OnPropertyChanged(nameof(Stock)); }
        }

        public string Location
        {
            get => _location;
            set { _location = value; OnPropertyChanged(nameof(Location)); }
        }

        public decimal Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public string ProductImage
        {
            get => _productImage;
            set { _productImage = value; OnPropertyChanged(nameof(ProductImage)); }
        }

        public DetailProductVM()
        {
            // Dummy data for testing
            ProductName = "ASUS ROG RTX 3070 Ti";
            Condition = "Bekas";
            Category = "Barang Elektronik";
            Stock = 5;
            Location = "Bogor";
            Price = 5000000;
            Description = "Kartu Grafis Rangkaian GeForce RTXTM 3070 didukung oleh Ampere — arsitektur NVIDIA generasi ke-2 RTX. Dibuat dengan Ray Tracing Core dan Tensor Core yang disempurnakan, " +
                "multiprosesor streaming baru, dan memori berkecepatan tinggi. Perangkat ini menghadirkan keunggulan yang Anda perlukan untuk menjalankan game tersulit.";
            ProductImage = "/img/rtx.png"; // Relative path to image
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
