using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Aplikasi_EX.Model;
using Aplikasi_EX.DataAccess;
using Aplikasi_EX.Utilities;
using System;

namespace Aplikasi_EX.ViewModel
{
    public class SignUpVM : INotifyPropertyChanged
    {
        private readonly UserRepository _userRepository;

        private string _username;
        private string _password;
        private string _email;
        private string _alamat;
        private string _phoneNumber; // Tambahkan properti PhoneNumber
        private string _accountType;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Alamat
        {
            get => _alamat;
            set { _alamat = value; OnPropertyChanged(nameof(Alamat)); }
        }

        public string PhoneNumber // Tambahkan properti PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        public string AccountType
        {
            get { return _accountType; }
            set
            {
                if (_accountType != value)
                {
                    _accountType = value;
                    OnPropertyChanged(nameof(AccountType));
                }
            }
        }

        public ICommand SignUpCommand { get; set; }

        public SignUpVM()
        {
            _userRepository = new UserRepository();
            SignUpCommand = new RelayCommand(async (parameter) => await ExecuteSignUpAsync(), CanExecuteSignUp);
        }

        private bool CanExecuteSignUp(object parameter)
        {
            try
            {
                return !string.IsNullOrEmpty(Username) &&
                       !string.IsNullOrEmpty(Password) &&
                       !string.IsNullOrEmpty(Email) &&
                       !string.IsNullOrEmpty(Alamat) &&
                       !string.IsNullOrEmpty(PhoneNumber) && // Tambahkan validasi PhoneNumber
                       !string.IsNullOrEmpty(AccountType);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in CanExecuteSignUp: {ex.Message}");
                return false;
            }
        }

        private async Task ExecuteSignUpAsync()
        {
            try
            {
                // Validasi input sebelum melanjutkan
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) ||
                    string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Alamat) ||
                    string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(AccountType))
                {
                    MessageBox.Show("Tolong lengkapi semua kolom.");
                    return;
                }

                var newUser = new User
                {
                    Name = Username,
                    Password = Password,
                    Email = Email,
                    Address = Alamat,
                    PhoneNumber = PhoneNumber, // Tambahkan PhoneNumber ke objek User
                    Type = AccountType
                };

                try
                {
                    await _userRepository.RegisterAsync(newUser);
                    MessageBox.Show("Registrasi berhasil!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Registrasi gagal pada saat akses database: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in ExecuteSignUpAsync: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
