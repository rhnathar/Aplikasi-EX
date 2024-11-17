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
using System.IO;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Messaging;

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
            WeakReferenceMessenger.Default.Register<ProductUpdatedMessage>(this, (r, m) =>
            {
                // Muat ulang produk ketika menerima pesan
                LoadProducts();
            });
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
                foreach (var product in productsFromDb)
                {
                    product.Image = ConvertBase64ToImage(product.ImagePath);
                }
                Products = new ObservableCollection<Product>(productsFromDb);
            }
        }
        private BitmapImage ConvertBase64ToImage(string base64String)
        {
            byte[] binaryData = Convert.FromBase64String(base64String);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();

            return bi;
        }
        void OpenAddProduct(object parameter)
        {
            // Create an instance of the popup window
            var addProductPopUpVM = new AddProductPopUpVM();
            addProductPopUpVM.ProductAdded += OnProductAdded;
            var addProductWindow = new AddProductPopUp { DataContext = addProductPopUpVM };

            // Show the popup as a dialog
            addProductWindow.ShowDialog();
        }
        private async void OnProductAdded(object sender, EventArgs e)
        {
            await LoadProducts();
        }
    }
}

