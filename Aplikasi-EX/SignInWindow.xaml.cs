﻿using System;
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

namespace Aplikasi_EX
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username;}
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _username = value;
                }
                else
                {
                    throw new ArgumentException("Username tidak boleh kosong.");
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _password = value;
                }
                else
                {
                    throw new ArgumentException("Password tidak boleh kosong.");
                }
            }
        }
        public SignInWindow()
        {
            InitializeComponent();
        }

        private bool ValidateLogin()
        {
            return Username == "admin" && Password == "12345";
        }

        public void Login()
        {
            Username = txtUsername.Text;
            Password = txtPassword.Text;

            if (ValidateLogin()) 
            {
                MessageBox.Show("Login berhasil!");
                Open_MainWindow(this, new RoutedEventArgs());
            }
            else
            {
                MessageBox.Show("Username atau Password salah.");
            }
        }

        private void Open_SignUp(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            this.Close();
        }

        private void Open_MainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SignInButton_Click (object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Name == "txtUsername" && textBox.Text == "Masukkan emailmu")
            {
                textBox.Text = "";
            }
            else if (textBox.Name == "txtPassword" && textBox.Text == "Masukkan passwordmu")
            {
                textBox.Text = "";
                textBox.Visibility = Visibility.Visible;
                textBox.Focus();
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Name == "txtUsername" && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Masukkan emailmu";
            }
            else if (textBox.Name == "txtPassword" && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Masukkan passwordmu";
            }
        }
    }
}