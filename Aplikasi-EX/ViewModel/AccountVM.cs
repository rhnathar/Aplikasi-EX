using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Aplikasi_EX.DataAccess;
using Aplikasi_EX.Model;

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

        // Constructor to initialize dummy data
        public AccountVM()
        {
            _orderRepository = new OrderRepository();
            if (UserSession.IsUserLoggedIn)
            {
                CurrentUser = UserSession.CurrentUser;
                Task.Run(async () => await LoadOrders());
            }
        }
        private async Task LoadOrders()
        {
            if (CurrentUser.Type == "Penjual")
            {
                var ordersFromDb = await _orderRepository.getSellerOrderAsync(CurrentUser.UserID);
                Orders = new ObservableCollection<Order>(ordersFromDb);
            }
            else if (CurrentUser.Type == "Pembeli")
            {
                var ordersFromDb = await _orderRepository.getBuyerOrderAsync(CurrentUser.UserID);
                Orders = new ObservableCollection<Order>(ordersFromDb);
            }
        }
    }
}
