using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_EX.Utilities;
using System.Collections.ObjectModel;
using Aplikasi_EX.Model;
using Aplikasi_EX.DataAccess;
using System.Windows.Input;

namespace Aplikasi_EX.ViewModel
{
    class SellerOrderVM : Utilities.ViewModelBase
    {
        private readonly OrderRepository _orderRepository;
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

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
                // Perbarui status command ketika SelectedOrder berubah
              ((RelayCommand)UpdateStatusCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand UpdateStatusCommand { get; }

        public SellerOrderVM()
        {
            _orderRepository = new OrderRepository();
            // Menginisialisasi UpdateStatusCommand dengan RelayCommand
            UpdateStatusCommand = new RelayCommand(async (param) => await UpdateStatus(), (param) => SelectedOrder != null);

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

        private async Task UpdateStatus()
        {
            if (SelectedOrder != null)
            {
                await _orderRepository.UpdateStatusOrderAsync(SelectedOrder);
                await LoadOrders();
            }
        }
    }
}
