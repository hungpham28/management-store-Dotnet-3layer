using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int ProId { get; set; }
        public string ProName { get; set; }
        public CategoryDTO category{ get; set; }
        public float price { get; set; }
        public int qty { get; set; }
    }
}
