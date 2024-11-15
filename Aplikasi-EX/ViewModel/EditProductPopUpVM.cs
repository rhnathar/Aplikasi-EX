using Aplikasi_EX.Model;
using Aplikasi_EX.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Aplikasi_EX.ViewModel
{
    public class EditProductPopUpVM : BaseViewModel
    {
        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand DeleteCommand { get; }

        public EditProductPopUpVM()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            CancelCommand = new RelayCommand(Cancel);
            DeleteCommand = new RelayCommand(Delete);
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

        private void Delete(object parameter)
        {
            //handle action
        }





    }

}
