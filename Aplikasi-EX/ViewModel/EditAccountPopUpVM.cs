using Aplikasi_EX.Utilities;
using System;
using System.Windows;
using System.Windows.Input;
using Aplikasi_EX.DataAccess;
using Aplikasi_EX.Model;
using System.Threading.Tasks;
using System.Linq;
using Aplikasi_EX.View;
using System.ComponentModel;

namespace Aplikasi_EX.ViewModel
{
    public class EditAccountPopUpVM : BaseViewModel
    {
        private readonly UserRepository _userRepository;

        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));

                // Set data ke properti individu saat CurrentUser diatur
                if (_currentUser != null)
                {
                    FullName = _currentUser.Name;
                    Email = _currentUser.Email;
                    Address = _currentUser.Address;
                    PhoneNumber = _currentUser.PhoneNumber;
                }
            }
        }

        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(nameof(FullName)); }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        private string _address;
        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(nameof(Address)); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        // Konstruktor tanpa parameter agar bisa diakses oleh XAML
        public EditAccountPopUpVM()
        {
            _userRepository = new UserRepository();

            // Ambil data dari sesi pengguna jika ada
            if (UserSession.IsUserLoggedIn)
            {
                CurrentUser = UserSession.CurrentUser;
            }

            ConfirmCommand = new RelayCommand(async (parameter) => await Confirm(parameter));
            CancelCommand = new RelayCommand(Cancel);
        }

        // Konstruktor dengan parameter jika Anda ingin menggunakan ini di luar XAML
        public EditAccountPopUpVM(int userID, string name, string address, string phoneNumber, string email) : this()
        {
            FullName = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            if (UserSession.IsUserLoggedIn)
            {
                CurrentUser = UserSession.CurrentUser;
            }
        }

        private async Task Confirm(object parameter)
        {
            try
            {
                var user = new User
                {
                    UserID = CurrentUser.UserID, // Pastikan UserID disertakan
                    Name = FullName,
                    Email = Email,
                    Address = Address,
                    Password = Password, // Pastikan Password juga ter-update jika diperlukan
                    PhoneNumber = PhoneNumber
                };

                await _userRepository.UpdateDataAccount(user);

                MessageBox.Show("Data berhasil diperbarui", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                Close(parameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(object parameter)
        {
            Close(parameter);
        }

        private void Close(object parameter)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive)?.Close();
        }
    }
}
