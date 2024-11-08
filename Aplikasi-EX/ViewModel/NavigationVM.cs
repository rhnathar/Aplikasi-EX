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

 

        //buyer POV
        public ICommand HomePageCommand { get; set; }
        public ICommand AccountCommand { get; set; }
        public ICommand AllProductCommand { get; set; }


        private void HomePage(object obj) => CurrentView = new HomePageVM();
        private void Account(object obj) => CurrentView = new AccountVM();
        private void AllProduct(object obj) => CurrentView = new AllProductsVM();


        

        public NavigationVM()
        {
            HomePageCommand = new RelayCommand(HomePage);
            AccountCommand = new RelayCommand(Account);
            AllProductCommand = new RelayCommand(AllProduct);
            CurrentView = new HomePageVM();
        }
    }
}
