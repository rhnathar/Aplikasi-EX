using System;
using System.Collections.ObjectModel;
using Aplikasi_EX.Model;

namespace Aplikasi_EX.ViewModel
{
    class AccountVM : Utilities.ViewModelBase
    {
        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser));}
        }

        // Orders collection
        public ObservableCollection<Order> Orders { get; set; }

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
            if (UserSession.IsUserLoggedIn)
            {
                CurrentUser = UserSession.CurrentUser;
            }

            // Initialize dummy data for Orders
            Orders = new ObservableCollection<Order>
            {
                new Order { OrderID = 1001, Name = "Laptop ASUS", Status = "IN PROGRESS", LastUpdated = DateTime.Now.AddDays(-1) },
                new Order { OrderID = 1002, Name = "Keyboard Razer", Status = "COMPLETED", LastUpdated = DateTime.Now.AddDays(-5) },
                new Order { OrderID = 1003, Name = "Mouse Logitech", Status = "CANCELED", LastUpdated = DateTime.Now.AddDays(-10) },
                new Order { OrderID = 1004, Name = "Monitor Samsung", Status = "IN PROGRESS", LastUpdated = DateTime.Now.AddDays(-2) }
            };
        }
    }
}
