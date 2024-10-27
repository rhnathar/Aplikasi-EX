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
        private object _currentview;

        public object CurrentView
        {
            get { return _currentview; }
            set
            {
                _currentview = value;
                OnPropertyChanged();
            }
        }

 

        //Auth Window  
        /*public ICommand SignUpCommand { get; set; }
        public ICommand SignInCommand { get; set; }


        private void SignUp(object obj) => CurrentView = new SignUpVM();
        private void SignIn(object obj) => CurrentView = new SignInVM();

        public NavigationVM()
        {
            SignUpCommand = new RelayCommand(SignUp);
            SignInCommand = new RelayCommand(SignIn);
        }*/
    }
}
