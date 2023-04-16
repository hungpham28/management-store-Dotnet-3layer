using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public int productCatID { get; set; }
        public decimal productPrice { get; set; }
        public int productQty { get; set; }
    }
}
