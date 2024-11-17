using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Aplikasi_EX.Model;
using Aplikasi_EX.ViewModel;


namespace Aplikasi_EX.View
{
    /// <summary>
    /// Interaction logic for DetailProduct.xaml
    /// </summary>
    public partial class DetailProduct : UserControl
    {
        public DetailProduct()
        {
            InitializeComponent();
            //DataContext = new DetailProductVM(ProductID);
        }

        private void decreaseButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as DetailProductVM;
            if (viewModel != null && viewModel.QuantityToBuy > 1)
            {
                viewModel.QuantityToBuy--; // Decrease quantity from ViewModel
            }
        }

        private void increaseButton_CLick(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as DetailProductVM;
            if (viewModel != null && viewModel.QuantityToBuy < viewModel.Stock) // Check if it doesn't exceed stock
            {
                viewModel.QuantityToBuy++; // Increase quantity in ViewModel
            }
        }

    }
}
