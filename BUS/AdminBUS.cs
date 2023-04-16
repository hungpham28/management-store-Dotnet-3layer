using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class AdminBUS
    {
        private AdminDAO adminDAO = new AdminDAO();
        public DataTable selectAll()
        {
            return adminDAO.SelectAll();
        }
        public bool InsertAdmin(string id, string name, string pass)
        {
            return adminDAO.InsertAdmin(id, name, pass) > 0;
        }
        public bool DeleteAdmin(string adminID)
        {
            return adminDAO.DeleteAdmin(adminID) > 0;
        }
        public bool checkDuplicateRecord(string id)
        {
            return adminDAO.checkDuplicateRecordDAO(id);
        }
        public bool UpdateAdmin(string adminID, string name, string pass)
        {
            return adminDAO.UpdateAdmin(adminID, name, pass) > 0;
        }
    }
}
