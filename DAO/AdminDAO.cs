using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class AdminDAO 
    {
        private DBConnect connect = new DBConnect();
        public DataTable FindAccountByUsernameAndPass(string id, string pass)
        {
            SqlCommand cmd = new SqlCommand("select top 1 AdminID,Password,FullName from tblAdmin where AdminID=@AdminID and Password=@Password", connect.GetCon());
            cmd.Parameters.AddWithValue("@AdminID", id);
            cmd.Parameters.AddWithValue("@Password", pass);
            connect.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.CloseCon();
            return dt;
        }
        public DataTable SelectAll()
        {
            SqlCommand cmd = new SqlCommand("select * from tblAdmin", connect.GetCon());
            connect.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.CloseCon();
            return dt;
        }
        public int DeleteAdmin(string adminID)
        {
            SqlCommand cmd = new SqlCommand("spDeleteAdmin", connect.GetCon());
            connect.OpenCon();
            cmd.Parameters.AddWithValue("@AdminID", adminID);
            cmd.CommandType = CommandType.StoredProcedure;
            int i = cmd.ExecuteNonQuery();
            connect.CloseCon();
            return i;
        }
        public int InsertAdmin(string adminID, string adminName, string adminPass)
        {
            SqlCommand cmd = new SqlCommand("spAddAdmin", connect.GetCon());
            connect.OpenCon();
            cmd.Parameters.AddWithValue("@AdminID", adminID);
            cmd.Parameters.AddWithValue("@FullName", adminName);
            cmd.Parameters.AddWithValue("@Password", adminPass);
            cmd.CommandType = CommandType.StoredProcedure;
            int i = cmd.ExecuteNonQuery();
            connect.CloseCon();
            return i;
        }
        public int UpdateAdmin(string adminId,string fullname,string password)
        {
            SqlCommand cmd = new SqlCommand("spUpdateAdmin", connect.GetCon());
            connect.OpenCon();
            cmd.Parameters.AddWithValue("@AdminID", adminId);
            cmd.Parameters.AddWithValue("@Password",password);
            cmd.Parameters.AddWithValue("@FullName", fullname);
            cmd.CommandType = CommandType.StoredProcedure;
            int i = cmd.ExecuteNonQuery();
            connect.CloseCon();
            return i;
        }
        public bool checkDuplicateRecordDAO(string id)
        {
            SqlCommand cmd = new SqlCommand("select AdminID from tblAdmin where AdminID=@ID", connect.GetCon());
            cmd.Parameters.AddWithValue("@ID",id);
            connect.OpenCon();
            var result = cmd.ExecuteScalar();
            connect.CloseCon() ;
            return result != null;
        }
    }
}
