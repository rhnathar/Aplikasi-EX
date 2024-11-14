using Aplikasi_EX.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Aplikasi_EX.DataAccess;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Aplikasi_EX.Model;

namespace Aplikasi_EX.ViewModel
{
    public class AddProductPopUpVM : BaseViewModel
    {
        private readonly ProductRepository _productrepository;
        public string ProductName { get; set; }
        public ObservableCollection<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
        public int Price { get; set; }
        public string Stock { get; set; }
        public string Description { get; set; }
        public string ProductPhoto { get; set; }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand UploadFileCommand { get; }

        public AddProductPopUpVM()
        {
            _productrepository = new ProductRepository();
            ConfirmCommand = new RelayCommand(async (parameter) => await Confirm(parameter));
            CancelCommand = new RelayCommand(Cancel);
            CloseCommand = new RelayCommand(Close);
            UploadFileCommand = new RelayCommand(UploadFile);
        }

        private async Task Confirm(object parameter)
        {
            var product = new Product
            {
                //ProductID = Guid.NewGuid(),
                ProductName = ProductName,
                Price = Price,
                DateAdded = DateTime.Now,
                Description = Description,
                ImagePath = ProductPhoto,
                //SellerID = Guid.NewGuid(),
                Quantity = int.TryParse(Stock, out var parsedStock) ? parsedStock : 0,
                //Condition = "Baru",
                Category = SelectedCategory
            };

            try
            {
                await _productrepository.InsertProductAsync(product);
                MessageBox.Show("Produk Berhasil Ditambahkan.");
                Close(parameter);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error saat menambahkan: " + ex.Message);
            }
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
    }
}
