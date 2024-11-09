using Aplikasi_EX.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Aplikasi_EX.ViewModel
{
    public class AddProductPopUpVM : BaseViewModel
    {
        public string ProductName { get; set; }
        public ObservableCollection<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        public string Description { get; set; }
        public string ProductPhoto { get; set; }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand CloseCommand { get; }

        private void Confirm(object parameter)
        {
            // Handle confirm action, such as saving data
            MessageBox.Show("Product saved successfully!");
            Close(parameter);
        }

        private void Cancel(object parameter)
        {
            // Handle cancel action
            Close(parameter);
        }

        private void Close(object parameter)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive)?.Close();
        }

        public AddProductPopUpVM()
        {
            // Initialize the categories list and commands
            Categories = new ObservableCollection<string> { "Kategori 1", "Kategori 2" };
            ConfirmCommand = new RelayCommand(Confirm);
            CancelCommand = new RelayCommand(Cancel);
            CloseCommand = new RelayCommand(Close);
        }
    }
}
