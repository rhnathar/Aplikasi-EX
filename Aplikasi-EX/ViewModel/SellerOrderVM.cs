using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_EX.Utilities;
using System.Collections.ObjectModel;
using Aplikasi_EX.Model;
using Aplikasi_EX.DataAccess;

namespace Aplikasi_EX.ViewModel
{
    class SellerOrderVM : Utilities.ViewModelBase
    {
        private readonly OrderRepository _orderRepository;
        // Orders collection
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set { _orders = value; OnPropertyChanged(nameof(Orders)); }
        }

        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); }
        }

        // Constructor to initialize dummy data for orders
        public SellerOrderVM()
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
            if (CurrentUser != null)
            {
                var ordersFromDb = await _orderRepository.getSellerOrderAsync(CurrentUser.UserID);
                Orders = new ObservableCollection<Order>(ordersFromDb);
            }
        }
    }
}
