using System.Collections.ObjectModel;
using Aplikasi_EX.Model;
using Aplikasi_EX.Utilities;
using Aplikasi_EX.View;
using System.Windows.Input;
using Aplikasi_EX.DataAccess;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System;

namespace Aplikasi_EX.ViewModel
{
    class SellerProductVM : Utilities.ViewModelBase
    {
        public ICommand OpenAddProductCommand { get; }
        private readonly ProductRepository _productRepository;
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
        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); }
        }
        public SellerProductVM()
        {
            _productRepository = new ProductRepository();
            if (UserSession.IsUserLoggedIn)
            {
                CurrentUser = UserSession.CurrentUser;
                InitializeAsync();
            }
            OpenAddProductCommand = new RelayCommand(OpenAddProduct);
        }
        private async void InitializeAsync()
        {
            await LoadProducts();
        }
        private async Task LoadProducts()
        {
            if (CurrentUser != null)
            {
                var productsFromDb = await _productRepository.GetSellerProductsAsync(CurrentUser.UserID);
                Products = new ObservableCollection<Product>(productsFromDb);
            }
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

