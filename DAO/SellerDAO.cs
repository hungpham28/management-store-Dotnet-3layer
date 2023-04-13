using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SellerDAO
    {
        private DBConnect connect = new DBConnect();
        public DataTable FindAccountByUsernameAndPass(string username, string pass)
        {
            SqlCommand cmd = new SqlCommand("select top 1 SellerName,SellerPass from tblSeller where SellerName=@SellerName and SellerPass=@SellerPass", connect.GetCon());
            cmd.Parameters.AddWithValue("@AdminID", username);
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
            SqlCommand cmd = new SqlCommand("select * from tblSeller", connect.GetCon());
            connect.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.CloseCon();
            return dt;
        }
        public object ExistAccountByUsername(string username)
        {
            SqlCommand cmd = new SqlCommand("select SellerName from tblSeller where SellerName=@SellerName", connect.GetCon());
            cmd.Parameters.AddWithValue("@SellerName", username);
            connect.OpenCon();
            object result = cmd.ExecuteScalar();
            connect.CloseCon();
            return result ;
        }

        public int Insert(string username,int age, string phone, string pass )
        {
            SqlCommand cmd = new SqlCommand("spSellerInsert", connect.GetCon());
            connect.OpenCon();
            cmd.Parameters.AddWithValue("@SellerName", username);
            cmd.Parameters.AddWithValue("@SellerAge", age);
            cmd.Parameters.AddWithValue("@SellerPhone", phone);
            cmd.Parameters.AddWithValue("@SellerPass", pass);
            cmd.CommandType = CommandType.StoredProcedure;
            int res= cmd.ExecuteNonQuery();
            connect.CloseCon();
            return res;
        }
        public int Update(int id,string username, int age, string phone, string pass)
        {
            SqlCommand cmd = new SqlCommand("spSellerUpadte", connect.GetCon());
            connect.OpenCon();
            cmd.Parameters.AddWithValue("@SellerID", id);
            cmd.Parameters.AddWithValue("@SellerName", username);
            cmd.Parameters.AddWithValue("@SellerAge", age);
            cmd.Parameters.AddWithValue("@SellerPhone", phone);
            cmd.Parameters.AddWithValue("@SellerPass", pass);
            cmd.CommandType = CommandType.StoredProcedure;
            int i = cmd.ExecuteNonQuery();
            connect.CloseCon();
            return i;
        }
        public int Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("spSellerDelete", connect.GetCon());
            connect.OpenCon();
            cmd.Parameters.AddWithValue("@SellerID", id);
            cmd.CommandType = CommandType.StoredProcedure;
            int i = cmd.ExecuteNonQuery();
            connect.CloseCon();
            return i;
        }
    }
}
