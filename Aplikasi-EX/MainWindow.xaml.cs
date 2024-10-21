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

namespace Aplikasi_EX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Open_DetailProduct(object sender, MouseButtonEventArgs e)
        {
            DetailProduct detailProduct = new DetailProduct();
            detailProduct.Show();
            this.Close();

        }

        private void Open_AccountInformation(object sender, MouseButtonEventArgs e)
        {
            AccountTemp accountTemp = new AccountTemp();
            accountTemp.Show();
            this.Close();
        }
    }
}
