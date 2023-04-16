using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace DAO
{
    public class BillDAO
    {
        private DBConnect connect = new DBConnect();

        public DataTable SelectAll()
        {
            SqlCommand cmd = new SqlCommand("spGetCategory", connect.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            connect.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.CloseCon();
            return dt;
        }
        public DataTable SelectAllBill()
        {
            SqlCommand cmd = new SqlCommand("spGetBillList", connect.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            connect.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.CloseCon();
            return dt;
        }

        public int Insert(string billId, string sellerId, string sellDate, double totalAmt)
        {
            SqlCommand cmd = new SqlCommand("spInsertBill", connect.GetCon());
            cmd.Parameters.AddWithValue("@Bill_ID", billId);
            cmd.Parameters.AddWithValue("@SellerID", sellerId);
            cmd.Parameters.AddWithValue("@SellDate", sellDate);
            cmd.Parameters.AddWithValue("@TotalAmt", Convert.ToDouble(totalAmt));
            cmd.CommandType = CommandType.StoredProcedure;
            connect.OpenCon();
            int i = cmd.ExecuteNonQuery();
            connect.CloseCon();
            return i;
        }
        public int Update(int id, string sellerId, string sellDate, double totalAmt)
        {
            SqlCommand cmd = new SqlCommand("spSellerUpadte", connect.GetCon());
            connect.OpenCon();
            cmd.Parameters.AddWithValue("@Bill_ID", id);
            cmd.Parameters.AddWithValue("@SellerID", sellerId);
            cmd.Parameters.AddWithValue("@SellDate", sellDate);
            cmd.Parameters.AddWithValue("@totalAmt", totalAmt);

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
