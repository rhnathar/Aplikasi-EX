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
using Aplikasi_EX.ViewModel;

namespace Aplikasi_EX.View
{
    /// <summary>
    /// Interaction logic for AllProducts.xaml
    /// </summary>
    public partial class AllProducts : UserControl
    {
        public AllProducts()
        {
            InitializeComponent();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is AllProductsVM viewModel)
            {
                viewModel.SortProducts();
            }
        }
    }
}
