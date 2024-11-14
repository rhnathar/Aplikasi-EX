using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        //public byte[] ProductImage { get; set; } -> ntar waktu connect db

        //nyoba pake gambar local
        public string ImagePath { get; set; }
        public int SellerID { get; set; }
        public int Quantity { get; set; }
        public int Condition { get; set; }

        //temporary placeholder buat binding category
        public string Category { get; set; }
    }
}
