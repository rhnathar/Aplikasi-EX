using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Aplikasi_EX.Model;
using Aplikasi_EX.DataAccess;
using Aplikasi_EX.Utilities;
using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;

namespace Aplikasi_EX.ViewModel
{
    public class SignInVM : INotifyPropertyChanged
    {
        private readonly UserRepository _userRepository;

        private string _email = string.Empty;
        private string _password = string.Empty;

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public ICommand LoginCommand { get; set; }

        public SignInVM()
        {
            _userRepository = new UserRepository();
            LoginCommand = new RelayCommand(async (parameter) => await ExecuteSignInAsync(), CanExecuteSignIn);
        }

        private bool CanExecuteSignIn(object parameter)
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private async Task ExecuteSignInAsync()
        {
            try
            {
                // Validasi input sebelum melanjutkan
                if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email))
                {
                    MessageBox.Show("Tolong lengkapi semua kolom.");
                    return;
                }

                try
                {
                    User user = await _userRepository.LoginAsync(Email, Password);
                    if (user != null) 
                    {
                        UserSession.CurrentUser = user;

                        if (user.Type == "Pembeli")
                        {
                            MessageBox.Show("Login berhasil, selamat datang pembeli!");
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                        }
                        else if (user.Type == "Penjual")
                        {
                            MessageBox.Show("Login berhasil, selamat datang penjual!");
                            SellerMainWindow sellerMainWindow = new SellerMainWindow();
                            sellerMainWindow.Show();
                        }
                        var signInWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is SignInWindow);
                        signInWindow?.Close();
                    }
                    else
                        MessageBox.Show("Login gagal, silahkan coba lagi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Login gagal pada saat akses database: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in ExecuteSignInAsync: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
