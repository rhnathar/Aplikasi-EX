using Aplikasi_EX.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.IO;
using Aplikasi_EX.DataAccess;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Aplikasi_EX.Model;
using System.ComponentModel;

namespace Aplikasi_EX.ViewModel
{
    public class AddProductPopUpVM : BaseViewModel
    {
        private readonly ProductRepository _productrepository;

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
        public ICommand CloseCommand { get; }
        public ICommand UploadFileCommand { get; }

        public AddProductPopUpVM()
        {
            _productrepository = new ProductRepository();
            if (UserSession.IsUserLoggedIn)
            {
                CurrentUser = UserSession.CurrentUser;
            }
            ConfirmCommand = new RelayCommand(async (parameter) => await Confirm(parameter));
            CancelCommand = new RelayCommand(Cancel);
            CloseCommand = new RelayCommand(Close);
            UploadFileCommand = new RelayCommand(UploadFile);
        }

        private async Task Confirm(object parameter)
        {
            var product = new Product
            {
                ProductName = ProductName,
                Price = Price,
                DateAdded = DateTime.Now,
                Description = Description,
                ImagePath = ProductPhoto,
                SellerID = CurrentUser.UserID,
                Quantity = Stock,
                Condition = Condition,
                Category = SelectedCategory
            };

            try
            {
                await _productrepository.InsertProductAsync(product);
                MessageBox.Show("Produk Berhasil Ditambahkan.");
                Close(parameter);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error saat menambahkan: " + ex.Message);
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
