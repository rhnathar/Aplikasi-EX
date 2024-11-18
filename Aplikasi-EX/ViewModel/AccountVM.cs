using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Aplikasi_EX.DataAccess;
using Aplikasi_EX.Model;
using Aplikasi_EX.Utilities;
using Aplikasi_EX.View;
using CommunityToolkit.Mvvm.Messaging;
using System.Linq;

namespace Aplikasi_EX.ViewModel
{
    class AccountVM : Utilities.ViewModelBase
    {
        private readonly OrderRepository _orderRepository;

        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser));}
        }

        // Orders collection
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set { _orders = value; OnPropertyChanged(nameof(Orders)); }
        }


        // Properties for user details
        public string Greeting => $"Hello, {CurrentUser?.Name}";

        public string FullName
        {
            get => CurrentUser?.Name;
            set
            {
                if (CurrentUser != null)
                {
                    CurrentUser.Name = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string Address
        {
            get => CurrentUser?.Address;
            set
            {
                if (CurrentUser != null)
                {
                    CurrentUser.Address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        public string Email
        {
            get => CurrentUser?.Email;
            set
            {
                if (CurrentUser != null)
                {
                    CurrentUser.Email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Username
        {
            get => CurrentUser?.Name; // Assuming Username is the same as Name
            set
            {
                if (CurrentUser != null)
                {
                    CurrentUser.Name = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string PhoneNumber
        {
            get => CurrentUser?.PhoneNumber;
            set
            {
                if (CurrentUser != null)
                {
                    CurrentUser.PhoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public ICommand OpenEditAccountCommand { get; }
        //public ICommand LogoutCommand { get; }

        // Constructor 
        public AccountVM()
        {
            _orderRepository = new OrderRepository();
            if (UserSession.IsUserLoggedIn)
            {
                CurrentUser = UserSession.CurrentUser;
                Task.Run(async () => await LoadOrders());
            }

            OpenEditAccountCommand = new RelayCommand(OpenEditAccount);
            //LogoutCommand = new RelayCommand(Logout);
            WeakReferenceMessenger.Default.Register<AccountUpdatedMessage>(this, (r, m) =>
            {
                // Muat ulang produk ketika menerima pesan
                OnAccountUpdated(m);
            });

        }
        private async Task LoadOrders()
        {
            if (CurrentUser != null)
            {
                var ordersFromDb = await _orderRepository.getBuyerOrderAsync(CurrentUser.UserID);
                Orders = new ObservableCollection<Order>(ordersFromDb);
            }
        }
        private void OnAccountUpdated(AccountUpdatedMessage message)
        {
            // Perbarui data akun
            CurrentUser = message.UpdatedUser;
            OnPropertyChanged(nameof(CurrentUser));
            OnPropertyChanged(nameof(Greeting));
            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(Address));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(PhoneNumber));
        }

        void OpenEditAccount(object parameter)
        {
            // Create an instance of the popup window
            var EditAccountWindow = new EditAccountPopUp();

            // Show the popup as a dialog
            EditAccountWindow.ShowDialog();
        }

        //void Logout(object parameter)
        //{
        //    SignInWindow signInWindow = new SignInWindow();
        //    signInWindow.Show();
            
        //    // Close the current window
        //    Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive)?.Close();         
        //}
    }
}
