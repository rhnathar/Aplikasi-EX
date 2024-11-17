using Aplikasi_EX.Model;
using Aplikasi_EX.Utilities;
using Aplikasi_EX.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Aplikasi_EX.ViewModel
{
	public class NavigationVM : Utilities.ViewModelBase
	{
		private object _currentView;
		private object _currentViewSeller;
		private string _searchText;

		public object CurrentView
		{
			get { return _currentView; }
			set
			{
				_currentView = value;
				OnPropertyChanged();
			}
		}

		public object CurrentViewSeller
		{
			get { return _currentViewSeller; }
			set
			{
				_currentViewSeller = value;
				OnPropertyChanged();
			}
		}
		private User _currentUser;
		public User CurrentUser
		{
			get => _currentUser;
			set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); }
		}

		public string SearchText
		{
			get => _searchText;
			set
			{
				_searchText = value;
				OnPropertyChanged();
			}
		}

		//buyer POV
		public ICommand HomePageCommand { get; set; }
		public ICommand AccountCommand { get; set; }
		public ICommand AllProductCommand { get; set; }
        public ICommand SearchProductCommand { get; set; }
        public ICommand SellerProductCommand { get; set; }
		public ICommand SellerOrderCommand { get; set; }
		public ICommand SellerAccountCommand { get; set; }
		public ICommand NavigateToDetailCommand { get; set; }
		public ICommand SearchBarCommand {get; set; }
		public ICommand BackToHomeCommand { get; set; }
		public ICommand NavigateBackToAllProductsCommand { get; set; }



        public void HomePage(object obj) => CurrentView = new HomePageVM();
		private void Account(object obj) => CurrentView = new AccountVM();
		// private void AllProduct(object obj) => CurrentView = new AllProductsVM();
		private void SellerProduct(object obj) => CurrentViewSeller = new SellerProductVM();
		private void SellerOrder(object obj) => CurrentViewSeller = new SellerOrderVM();
		private void SellerAccount(object obj) => CurrentViewSeller = new SellerAccountVM();
		private void NavigateToAllProduct(object obj)
		{
			if (obj is string category)
			{
				CurrentView = new AllProductsVM(category);
			}
		}
        private void NavigateToSearchProduct(object obj)
		{
            if (obj is string search)
            {
                CurrentView = new AllProductsVM(search, true);
            }
        }
		private void SearchBar(object obj)
		{
			if (obj is string searchText)
			{
				NavigateToSearchProduct(searchText);
			}
		}
		public void NavigateToDetailProduct(int productID)
		{
			CurrentView = new DetailProductVM(productID);
		}

		public void BackToHome(object obj)
		{
			CurrentView = new HomePageVM();
		}

        private void NavigateBackToAllProducts(object obj)
        {
            if (obj is string category)
            {
                CurrentView = new AllProductsVM(category);
            }
        }

        public NavigationVM()
		{
			if (UserSession.IsUserLoggedIn)
			{
				CurrentUser = UserSession.CurrentUser;
				if (CurrentUser.Type == "Pembeli")
				{
					HomePageCommand = new RelayCommand(HomePage);
					AccountCommand = new RelayCommand(Account);
					//AllProductCommand = new RelayCommand(AllProduct);
					AllProductCommand = new RelayCommand(NavigateToAllProduct);
					SearchProductCommand = new RelayCommand(NavigateToSearchProduct);
                    NavigateToDetailCommand = new RelayCommand(param =>
                    {
                        if (param is Product product)
                        {
                            NavigateToDetailProduct(product.ProductID);
                        }
                    });
                    SearchBarCommand = new RelayCommand(SearchBar);
                    BackToHomeCommand = new RelayCommand(BackToHome);
                    NavigateBackToAllProductsCommand = new RelayCommand(NavigateBackToAllProducts);

                    CurrentView = new HomePageVM();

				}
				else if (CurrentUser.Type == "Penjual")
				{
					SellerProductCommand = new RelayCommand(SellerProduct);
					SellerOrderCommand = new RelayCommand(SellerOrder);
					SellerAccountCommand = new RelayCommand(SellerAccount);
					CurrentViewSeller = new SellerProductVM();
				}
			}
		}
	}
}
