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
        public ICommand UploadFileCommand { get; }

        private void Confirm(object parameter)
        {
            MessageBox.Show($"Product Name: {ProductName}\n" +
                         $"Category: {SelectedCategory}\n" +
                         $"Price: {Price}\n" +
                         $"Stock: {Stock}\n" +
                         $"Description: {Description}\n" +
                         $"Product Photo: {ProductPhoto}");
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

        private void UploadFile(object parameter)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                ProductPhoto = openFileDialog.FileName;
                OnPropertyChanged(nameof(ProductPhoto)); // Trigger UI update if bound to the view
            }
        }

        public AddProductPopUpVM()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            CancelCommand = new RelayCommand(Cancel);
            CloseCommand = new RelayCommand(Close);
            UploadFileCommand = new RelayCommand(UploadFile);
        }
    }
}
