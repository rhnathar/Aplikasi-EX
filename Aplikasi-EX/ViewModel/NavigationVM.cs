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


        private void HomePage(object obj) => CurrentView = new HomePageVM();
        private void Account(object obj) => CurrentView = new AccountVM();


        /*public ICommand SignUpCommand { get; set; }
        public ICommand SignInCommand { get; set; }


        private void SignUp(object obj) => CurrentView = new SignUpVM();
        private void SignIn(object obj) => CurrentView = new SignInVM();

        }*/


        public NavigationVM()
        {
            HomePageCommand = new RelayCommand(HomePage);
            AccountCommand = new RelayCommand(Account);
            CurrentView = new HomePageVM();
        }
    }
}
