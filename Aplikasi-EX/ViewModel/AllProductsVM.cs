using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Aplikasi_EX.Model;
using Aplikasi_EX.DataAccess;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using Aplikasi_EX.Utilities;
using System.Windows;

namespace Aplikasi_EX.ViewModel
{
	class AllProductsVM : Utilities.ViewModelBase
	{
		private readonly ProductRepository _productRepository;
		private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
                ProductCount = _products?.Count ?? 0; // Update ProductCount setiap kali Products diubah
            }
        }

        private int _productCount;
        public int ProductCount
        {
            get => _productCount;
            private set
            {
                _productCount = value;
                OnPropertyChanged();
            }
        }
        private string _selectedSortOption;
        public string SelectedSortOption
        {
            get => _selectedSortOption;
            set
            {
                _selectedSortOption = value;
                OnPropertyChanged();
                SortProducts();
            }
        }

        public ICommand NavigateToDetailCommand { get; }
        public ICommand SortCommand { get; }

        public AllProductsVM(string category)
		{
			_productRepository = new ProductRepository();
			InitializeAsync(category);
			NavigateToDetailCommand = new RelayCommand(param =>
            {
                if (param is Product product)
                {
                    NavigateToDetail(product.ProductID);
                }
            });
        }
        public AllProductsVM(string search, bool isSearch)
        {
            _productRepository = new ProductRepository();
            InitializeAsync(search, isSearch);
            NavigateToDetailCommand = new RelayCommand(param =>
            {
                if (param is Product product)
                {
                    NavigateToDetail(product.ProductID);
                }
            });
        }
        public AllProductsVM(string search, string category)
        {
            _productRepository = new ProductRepository();
            InitializeAsync(search, category);
            NavigateToDetailCommand = new RelayCommand(param =>
            {
                if (param is Product product)
                {
                    NavigateToDetail(product.ProductID);
                }
            });
        }

        private async void InitializeAsync(string category)
		{
			await LoadProducts(category);
		}
		private async void InitializeAsync(string search, string category)
        {
            await SearchProducts(search, category);
        }
        private async void InitializeAsync(string search, bool isSearch)
        {
            await SearchProducts(search);
        }

        private async Task LoadProducts(string category)
		{
			var productsFromDb = await _productRepository.GetProductsByCategoryAsync(category);
			foreach (var product in productsFromDb)
			{
				product.Image = ConvertBase64ToImage(product.ImagePath);
			}
			Products = new ObservableCollection<Product>(productsFromDb);
		}
		private async Task SearchProducts(string search, string category)
        {
            var productsFromDb = await _productRepository.GetProductsBySearchAndCategoryAsync(search, category);
            foreach (var product in productsFromDb)
            {
                product.Image = ConvertBase64ToImage(product.ImagePath);
            }
            Products = new ObservableCollection<Product>(productsFromDb);
        }
        private async Task SearchProducts(string search)
        {
            var productsFromDb = await _productRepository.GetProductsBySearchAsync(search);
            foreach (var product in productsFromDb)
            {
                product.Image = ConvertBase64ToImage(product.ImagePath);
            }
            Products = new ObservableCollection<Product>(productsFromDb);
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

		private void NavigateToDetail(int productID)
		{
			var navigationVM = (NavigationVM)App.Current.MainWindow.DataContext;
			navigationVM.NavigateToDetailProduct(productID);
		}
        public void SortProducts()
        {
            if (SelectedSortOption == "Paling Murah")
            {
                Products = new ObservableCollection<Product>(Products.OrderBy(p => p.Price));
            }
            else if (SelectedSortOption == "Paling Mahal")
            {
                Products = new ObservableCollection<Product>(Products.OrderByDescending(p => p.Price));
            }
        }
        public AllProductsVM()
		{
		}
	}
}
