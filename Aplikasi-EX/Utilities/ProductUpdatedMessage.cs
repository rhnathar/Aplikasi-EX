using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Utilities
{
    public class ProductUpdatedMessage
    {
        public int ProductID { get; }
        public ProductUpdatedMessage(int productID)
        {
            ProductID = productID;
        }
    }
}
