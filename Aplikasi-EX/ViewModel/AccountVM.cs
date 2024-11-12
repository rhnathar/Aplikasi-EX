using System;
using System.Collections.ObjectModel;
using Aplikasi_EX.Model;

namespace Aplikasi_EX.ViewModel
{
    class AccountVM : Utilities.ViewModelBase
    {
        // User account information properties
        private string _greeting;
        private string _fullName;
        private string _address;
        private string _email;
        private string _username;
        private string _phoneNumber;

        // Orders collection
        public ObservableCollection<Order> Orders { get; set; }

        // Properties for user details
        public string Greeting
        {
            get => _greeting;
            set { _greeting = value; OnPropertyChanged(nameof(Greeting)); }
        }

        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(nameof(FullName)); }
        }

        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(nameof(Address)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        // Constructor to initialize dummy data
        public AccountVM()
        {
            // Initialize dummy data for user details
            Greeting = "Halo, Kevin";
            FullName = "Kevin Gilbert";
            Address = "East Tejturi Bazar, Word No. 04, Road No. 13/x, House no. 1320/C, Flat No. 5D, Dhaka - 1200, Bangladesh";
            Email = "kevin.gilbert@gmail.com";
            Username = "kevin";
            PhoneNumber = "+1-202-555-0118";

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
