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
            // Parse the current quantity from the TextBlock
            if (int.TryParse(QuantityTextBlock.Text, out int quantity))
            {
                // Decrease the quantity by 1, ensuring it doesn't go below 1
                if (quantity > 1)
                {
                    quantity--;
                    QuantityTextBlock.Text = quantity.ToString();
                }
            }
        }

        private void increaseButton_CLick(object sender, RoutedEventArgs e)
        {
            // Parse the current quantity from the TextBlock
            if (int.TryParse(QuantityTextBlock.Text, out int quantity))
            {
                // Increase the quantity by 1
                quantity++;
                QuantityTextBlock.Text = quantity.ToString();
            }
        }
    }
}
