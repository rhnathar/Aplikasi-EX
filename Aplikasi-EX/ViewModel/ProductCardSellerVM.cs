using Aplikasi_EX.Model;
using Aplikasi_EX.Utilities;
using Aplikasi_EX.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Aplikasi_EX.Utilities;

namespace Aplikasi_EX.ViewModel
{
    class ProductCardSellerVM : Utilities.ViewModelBase
    {

        public ICommand OpenEditProductCommand { get; set; }

        public ProductCardSellerVM() 
        {
            OpenEditProductCommand = new RelayCommand(OpenEditProduct);
        }

        void OpenEditProduct(object parameter)
        {
            var EditProductWindow = new EditProductPopUp();
            EditProductWindow.ShowDialog();
        }

    }

}
