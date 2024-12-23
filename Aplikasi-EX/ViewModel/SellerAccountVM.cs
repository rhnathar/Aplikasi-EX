﻿using System;
using Aplikasi_EX.DataAccess;
using System.Collections.ObjectModel;
using Aplikasi_EX.Model;
using Aplikasi_EX.Utilities;
using System.Threading.Tasks;
using System.Windows.Input;
using Aplikasi_EX.View;
using CommunityToolkit.Mvvm.Messaging;

namespace Aplikasi_EX.ViewModel
{
    class SellerAccountVM : Utilities.ViewModelBase
    {
        private readonly OrderRepository _orderRepository;

        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); }
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

        // Constructor to initialize dummy data
        public SellerAccountVM()
        {
            if (UserSession.IsUserLoggedIn)
            {
                CurrentUser = UserSession.CurrentUser;
            }

            OpenEditAccountCommand = new RelayCommand(OpenEditAccount);
            WeakReferenceMessenger.Default.Register<AccountUpdatedMessage>(this, (r, m) =>
            {
                // Muat ulang produk ketika menerima pesan
                OnAccountUpdated(m);
            });
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
    }
}
