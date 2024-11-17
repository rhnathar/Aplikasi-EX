using Aplikasi_EX.DataAccess;
using Aplikasi_EX.Model;
using Aplikasi_EX.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Xml.Linq;
using Aplikasi_EX.View;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Messaging;

namespace Aplikasi_EX.ViewModel
{
    public class EditProductPopUpVM : Utilities.ViewModelBase
    {
        private readonly ProductRepository _productrepository;

        private Product _currentProduct;
        public Product CurrentProduct
        {
            get => _currentProduct;
            set
            {
                _currentProduct = value;
                OnPropertyChanged(nameof(CurrentProduct));
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
        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UploadFileCommand { get; }

        public event Action ProductUpdated;
        public EditProductPopUpVM(int ProductID)
        {
            _productrepository = new ProductRepository();
            if (UserSession.IsUserLoggedIn)
            {
                CurrentUser = UserSession.CurrentUser;
                _ = LoadProductAsync(ProductID);
            }
            ConfirmCommand = new RelayCommand(async (parameter) => await Confirm(parameter));
            CancelCommand = new RelayCommand(Cancel);
            DeleteCommand = new RelayCommand(Delete);
            UploadFileCommand = new RelayCommand(UploadFile);
        }

        private async Task LoadProductAsync(int ProductID)
        {
            try
            {
                CurrentProduct = await _productrepository.GetProductsByIDAsync(ProductID);
                if (CurrentProduct != null)
                {
                    ProductName = CurrentProduct.ProductName;
                    Condition = CurrentProduct.Condition;
                    Price = CurrentProduct.Price;
                    Stock = CurrentProduct.Quantity;
                    Description = CurrentProduct.Description;
                    SelectedCategory = CurrentProduct.Category;
                    ProductPhoto = CurrentProduct.ImagePath;
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

        private async Task Confirm(object parameter)
        {
            // Validasi apakah data produk tersedia
            if (CurrentProduct == null)
            {
                MessageBox.Show("Produk tidak ditemukan. Silakan muat ulang.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Perbarui CurrentProduct berdasarkan data input pengguna
            CurrentProduct.ProductName = ProductName;
            CurrentProduct.Price = Price;
            CurrentProduct.Quantity = Stock;
            CurrentProduct.Description = Description;
            CurrentProduct.ImagePath = ProductPhoto;
            CurrentProduct.Condition = Condition;
            CurrentProduct.Category = SelectedCategory;

            try
            {
                // Update produk di database melalui repository
                await _productrepository.UpdateProductAsync(CurrentProduct);
                WeakReferenceMessenger.Default.Send(new ProductUpdatedMessage(CurrentProduct.ProductID));
                // Berikan notifikasi sukses
                MessageBox.Show("Produk berhasil diperbarui.", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                // Tutup jendela
                Close(parameter);
            }
            catch (Exception ex)
            {
                // Berikan notifikasi error
                MessageBox.Show($"Terjadi kesalahan saat memperbarui produk: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Cancel(object parameter)
        {
            // Handle cancel action
            Close(parameter);
        }

        private void Close(object parameter)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive)?.Close();
        }

        private void Delete(object parameter)
        {
            //handle action
        }

        private void UploadFile(object parameter)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                ProductPhoto = ConvertImageToBase64(openFileDialog.FileName);
                OnPropertyChanged(nameof(ProductPhoto)); // Trigger UI update if bound to the view
            }
        }
        public string ConvertImageToBase64(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageBytes);
        }
    }

}
