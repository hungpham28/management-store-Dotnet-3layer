using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AdminDAO 
    {
        private DBConnect connect = new DBConnect();
        public DataTable FindAccountByUsernameAndPass(string username, string pass)
        {
            SqlCommand cmd = new SqlCommand("select top 1 AdminID,Password,FullName from tblAdmin where AdminID=@AdminID and Password=@Password", connect.GetCon());
            cmd.Parameters.AddWithValue("@AdminID", username);
            cmd.Parameters.AddWithValue("@Password", pass);
            connect.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.CloseCon();
            return dt;
        }
    }
}
