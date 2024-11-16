﻿using System;
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
			}
		}

		public ICommand NavigateToDetailCommand { get; }

		public AllProductsVM(string category)
		{
			_productRepository = new ProductRepository();
			InitializeAsync(category);
			NavigateToDetailCommand = new RelayCommand(param => NavigateToDetail((Product)param));
		}
        public AllProductsVM(string search, bool isSearch)
        {
            _productRepository = new ProductRepository();
            InitializeAsync(search, isSearch);
            NavigateToDetailCommand = new RelayCommand(param => NavigateToDetail((Product)param));
        }

        private async void InitializeAsync(string category)
		{
			await LoadProducts(category);
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

		private void NavigateToDetail(Product product)
		{
			var navigationVM = (NavigationVM)App.Current.MainWindow.DataContext;
			navigationVM.NavigateToDetailProduct(product);
		}

		public AllProductsVM()
		{
		}
	}
}
