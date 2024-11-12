using System;
using Aplikasi_EX.Model;
using Aplikasi_EX.Utilities;

namespace Aplikasi_EX.ViewModel
{
    class SellerAccountVM : Utilities.ViewModelBase
    {
        private string _greeting;
        private string _fullName;
        private string _address;
        private string _email;
        private string _username;
        private string _phoneNumber;

        // Properties for seller account details
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
        public SellerAccountVM()
        {
            // Dummy data for testing
            Greeting = "Halo, Seller Kevin";
            FullName = "Kevin Gilbert";
            Address = "East Tejturi Bazar, Word No. 04, Road No. 13/x, House no. 1320/C, Flat No. 5D, Dhaka - 1200, Bangladesh";
            Email = "seller.kevin@gmail.com";
            Username = "seller_kevin";
            PhoneNumber = "+1-202-555-0123";
        }
    }
}
