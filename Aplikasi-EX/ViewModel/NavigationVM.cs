using Aplikasi_EX.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aplikasi_EX.ViewModel
{
    class NavigationVM : Utilities.ViewModelBase
    {
        private object _currentView;

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
            get { return _currentView; }
            set
            {
                _currentView = value; 
                OnPropertyChanged();
            }
        }

 

        //buyer POV
        public ICommand HomePageCommand { get; set; }
        public ICommand AccountCommand { get; set; }
        public ICommand AllProductCommand { get; set; }
        public ICommand SellerProductCommand { get; set; }
        public ICommand SellerOrderCommand { get; set; }
        public ICommand SellerAccountCommand { get; set; }


        private void HomePage(object obj) => CurrentView = new HomePageVM();
        private void Account(object obj) => CurrentView = new AccountVM();
        private void AllProduct(object obj) => CurrentView = new AllProductsVM();
        private void SellerProduct (object obj) => CurrentViewSeller = new SellerProductVM();
        private void SellerOrder (object obj) => CurrentViewSeller = new SellerOrderVM();
        private void SellerAccount (object obj) => CurrentViewSeller = new SellerAccountVM();


        

        public NavigationVM()
        {
            HomePageCommand = new RelayCommand(HomePage);
            AccountCommand = new RelayCommand(Account);
            AllProductCommand = new RelayCommand(AllProduct);

            SellerProductCommand = new RelayCommand(SellerProduct);
            SellerOrderCommand = new RelayCommand (SellerOrder);
            SellerAccountCommand = new RelayCommand(SellerAccount);

            CurrentView = new HomePageVM();
            CurrentViewSeller = new SellerProductVM();
        }
    }
}
