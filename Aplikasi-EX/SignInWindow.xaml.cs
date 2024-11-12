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
using System.Windows.Shapes;
using Npgsql;
using System.IO;
using Microsoft.Extensions.Configuration;
using Aplikasi_EX.ViewModel;

namespace Aplikasi_EX
{
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
            DataContext = new Aplikasi_EX.ViewModel.SignInVM();
        }

        private void Open_SignUp(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            this.Close();
        }
        private void close_app(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
