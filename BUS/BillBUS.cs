using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BillBUS
    {
        private BillDAO dao = new BillDAO();


        public DataTable getAllBill()
        {
            return dao.SelectAllBill();
        }
        public bool Add(BillDTO bill)
        {
            return dao.Insert(bill.billId, bill.sellerID, bill.sellDate, bill.totalAmt) > 0;
        }
        /* public bool Update(BillDTO bill)
         {
             return dao.Update(bill.billId, bill.sellerID, bill.sellDate, bill.totalAmt) > 0;
         }*/
        /* public bool DeleteById(int id)
         {
             return categoryDAO.Delete(id) > 0;
         }*/
    }
}
