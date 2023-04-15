using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDTO
    {
        public string billId { get; set; }
        
        public string sellerID { get; set; }
        public string sellDate { get; set; }
        public double totalAmt { get; set; }
    }
}
