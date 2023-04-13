using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SellerBUS
    {
        private SellerDAO sellerDAO=new SellerDAO();
        public DataTable getAllSeller()
        {
           return sellerDAO.SelectAll();
        }

        public bool IsExistUsername(string username)
        {
            return sellerDAO.ExistAccountByUsername(username)!=null;  
        }
        public bool Add(SellerDTO seller)
        {
            return sellerDAO.Insert(seller.sellerName,seller.sellerAge,seller.sellerPhone,seller.sellerPass)>0;
        }
        public bool Update(SellerDTO seller)
        {
            return sellerDAO.Update(seller.sellerId,seller.sellerName, seller.sellerAge,
                seller.sellerPhone, seller.sellerPass) > 0;
        }
        public bool DeleteById(int id)
        {
            return sellerDAO.Delete(id)>0;
        }
    }
}
