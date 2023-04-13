using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class AccountBUS
    {
        private AdminDAO adminDAO=new AdminDAO();
        private SellerDAO sellerDAO=new SellerDAO();
        public AdminDTO checkAdmin(AccountDTO account)
        {
            DataTable dt= adminDAO.FindAccountByUsernameAndPass(account.username, account.password);
            if (dt.Rows.Count > 0)
            {
                AdminDTO admin = new AdminDTO();
                admin.fullname = dt.Rows[0].Field<String>("fullname");
                admin.adminId = dt.Rows[0].Field<String>("adminId");
                admin.password = dt.Rows[0].Field<String>("password");
                return admin;
            }
            return null;
        }
        public SellerDTO checkSeller(AccountDTO account)
        {
            DataTable dt=sellerDAO.FindAccountByUsernameAndPass(account.username,account.password);
            if (dt.Rows.Count > 0)
            {
                SellerDTO seller = new SellerDTO();
                seller.sellerName = dt.Rows[0].Field<String>("fullname");
                seller.sellerId = dt.Rows[0].Field<int>("sellerId");
                seller.sellerPass = dt.Rows[0].Field<String>("sellerPass");
                seller.sellerPhone = dt.Rows[0].Field<String>("sellerPhone");
                return seller;
            }
            return null;
        }
    }
}
