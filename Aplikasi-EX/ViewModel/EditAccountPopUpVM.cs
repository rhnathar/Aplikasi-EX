using Aplikasi_EX.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Aplikasi_EX.ViewModel
{
    internal class EditAccountPopUpVM : BaseViewModel
    {
        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public EditAccountPopUpVM()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Confirm(object parameter)
        {
            //handle confirm action
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


    }
}
