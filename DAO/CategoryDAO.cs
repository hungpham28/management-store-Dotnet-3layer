using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CategoryDAO
    {
        private DBConnect connect = new DBConnect();
        public DataTable SelectAll()
        {
            SqlCommand cmd = new SqlCommand("select * from tblCategory", connect.GetCon());
            connect.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.CloseCon();
            return dt;
        }
        public object existCategory(string categoryName, int id)
        {
            SqlCommand cmd = new SqlCommand("select CategoryName from tblCategory where CategoryName=@CategoryName and CatID!=@CatID", connect.GetCon());
            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
            cmd.Parameters.AddWithValue("@CatID", Convert.ToInt32(id));
            connect.OpenCon();
            var result = cmd.ExecuteScalar();
            connect.CloseCon();
            return result;
        }
        public object existCategory(string categoryName)
        {
            SqlCommand cmd = new SqlCommand("select CategoryName from tblCategory where CategoryName=@CategoryName", connect.GetCon());
            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
            //cmd.Parameters.AddWithValue("@CatID", Convert.ToInt32(id));
            connect.OpenCon();
            var result = cmd.ExecuteScalar();
            connect.CloseCon();
            return result;
        }
        public DataTable spGetCategory()
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
        public DataTable rlCategory()
        {
            SqlCommand cmd = new SqlCommand("select  CatID as CategoryID,CategoryName,CategoryDesc as CategoryDescription from tblCategory", connect.GetCon());
            connect.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.CloseCon();
            return dt;
        }

        public int Insert(string categoryName, string categoryDesc)
        {
            SqlCommand cmd = new SqlCommand("spCatInsert", connect.GetCon());
            connect.OpenCon();
            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
            cmd.Parameters.AddWithValue("@CategoryDesc", categoryDesc);
            cmd.CommandType = CommandType.StoredProcedure;
            int res = cmd.ExecuteNonQuery();
            connect.CloseCon();
            return res;
        }
        public int Update(int catId, string categoryName, string categoryDesc)
        {
            SqlCommand cmd = new SqlCommand("spCatUpdate", connect.GetCon());
            connect.OpenCon();
            cmd.Parameters.AddWithValue("@CatID", catId);
            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
            cmd.Parameters.AddWithValue("@CategoryDesc", categoryDesc);
            cmd.CommandType = CommandType.StoredProcedure;
            int i = cmd.ExecuteNonQuery();
            connect.CloseCon();
            return i;
        }
        public int Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("spCatDelete", connect.GetCon());
            connect.OpenCon();
            cmd.Parameters.AddWithValue("@CatID", id);
            cmd.CommandType = CommandType.StoredProcedure;
            int i = cmd.ExecuteNonQuery();
            connect.CloseCon();
            return i;
        }
    }
}
