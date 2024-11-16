using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Aplikasi_EX.Model;

namespace Aplikasi_EX.ViewModel
{
	public class DetailProductVM : Utilities.ViewModelBase
	{
		private Product _product;
		public Product Product
		{
			get => _product;
			set
			{
				_product = value;
				OnPropertyChanged();
			}
		}

		public DetailProductVM(Product product)
		{
			Product = product;
		}
	}
}

