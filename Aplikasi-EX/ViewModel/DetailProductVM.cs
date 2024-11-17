using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Aplikasi_EX.Model;
using System.Windows.Media.Imaging;
using Aplikasi_EX.DataAccess;
using System.Windows.Input;
using Aplikasi_EX.Utilities;
using System.Threading.Tasks;
using System.Windows;
using System.Threading.Channels;
using System.IO;

namespace Aplikasi_EX.ViewModel
{
	public class DetailProductVM : Utilities.ViewModelBase
	{
		private readonly ProductRepository _productRepository;
		private Product _currentProduct;
		public Product CurrentProduct
		{
			get => _currentProduct;
			set
			{
				_currentProduct = value;
				OnPropertyChanged(nameof(CurrentProduct));
			}
		}
        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); }
        }
        private string _productName;
        public string ProductName
        {
            get => _productName;
            set { _productName = value; OnPropertyChanged(nameof(ProductName)); }
        }
        private string _condition;
        public string Condition
        {
            get => _condition;
            set { _condition = value; OnPropertyChanged(nameof(Condition)); }
        }
        private int _price;
        public int Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }
        private int _stock;
        public int Stock
        {
            get => _stock;
            set { _stock = value; OnPropertyChanged(nameof(Stock)); }
        }
        private string _description;
        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }
        private string _productPhoto;
        public string ProductPhoto
        {
            get => _productPhoto;
            set { _productPhoto = value; OnPropertyChanged(nameof(ProductPhoto)); }
        }
        private string _selectedCategory;
        public string SelectedCategory
        {
            get => _selectedCategory;
            set { _selectedCategory = value; OnPropertyChanged(nameof(SelectedCategory)); }
        }

        public ICommand BuyCommand { get; }

        public DetailProductVM(int ProductID)
		{
            _productRepository = new ProductRepository();
            if (UserSession.IsUserLoggedIn)
            {
                CurrentUser = UserSession.CurrentUser;
                _ = LoadProductAsync(ProductID);
            }
            BuyCommand = new RelayCommand(async (parameter) => await Buy(parameter));
		}

        private async Task LoadProductAsync(int ProductID)
        {
            try
            {
                CurrentProduct = await _productRepository.GetProductsByIDAsync(ProductID);
                if (CurrentProduct != null)
                {
                    ProductName = CurrentProduct.ProductName;
                    Condition = CurrentProduct.Condition;
                    Price = CurrentProduct.Price;
                    Stock = CurrentProduct.Quantity;
                    Description = CurrentProduct.Description;
                    ProductPhoto = CurrentProduct.ImagePath;
                    MessageBox.Show($"Produk dengan ID {ProductID} ditemukan");
                }
                else
                {
                    MessageBox.Show($"Produk dengan ID {ProductID} tidak ditemukan", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data produk: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task Buy(object parameter)
        {
            if (CurrentProduct == null)
            {
                MessageBox.Show("Produk tidak ditemukan. Silakan muat ulang.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            CurrentProduct.Quantity = Stock;

            try
            {
                await _productRepository.BuyProductAsync(CurrentProduct);
                MessageBox.Show("Produk berhasil dibeli, Silahkan Menunggu.", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                Close(parameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat membeli produk: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Close (object parameter)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive)?.Close();
        }

        public string ConvertImageToBase64(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageBytes);
        }
    }
}

