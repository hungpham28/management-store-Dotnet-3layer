using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ProductDAO
    {
        private DBConnect dbCon = new DBConnect();
        public DataTable selectAllProduct()
        {
            SqlCommand cmd=new SqlCommand("spGetAllProductList",dbCon.GetCon());
            dbCon.OpenCon();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dbCon.CloseCon();
            return dt;
        }
        public DataTable GetAllProductList_SearchByCatDAO(int id) {
            SqlCommand cmd = new SqlCommand("spGetAllProductList_SearchByCat", dbCon.GetCon());
            cmd.Parameters.AddWithValue("@ProdCatID", id);
            cmd.CommandType = CommandType.StoredProcedure;
            dbCon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool CheckDuplicateProductDAO(string productName,int productCatID)
        {
            SqlCommand cmd = new SqlCommand("spCheckDuplicateProduct", dbCon.GetCon());
            cmd.Parameters.AddWithValue("@ProdName", productName);
            cmd.Parameters.AddWithValue("@ProdCatID", productCatID);
            cmd.CommandType = CommandType.StoredProcedure;
            dbCon.OpenCon();
            var result = cmd.ExecuteScalar();
            return result!=null;
            dbCon.CloseCon() ;
        }
        public int InsertProductDAO(string ProdName,int cateId,decimal price,int qty)
        {
            SqlCommand cmd = new SqlCommand("spInsertProduct", dbCon.GetCon());
            dbCon.OpenCon();
            cmd.Parameters.AddWithValue("@ProdName", ProdName);
            cmd.Parameters.AddWithValue("@ProdCatID", cateId);
            cmd.Parameters.AddWithValue("@ProdPrice",price);
            cmd.Parameters.AddWithValue("@ProdQty", qty);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd.ExecuteNonQuery();
        }
        public int UpdateProductDAO(string ProdName, int cateId, decimal price, int qty)
        {
            SqlCommand cmd = new SqlCommand("spUpdateProduct", dbCon.GetCon());
            dbCon.OpenCon();
            cmd.Parameters.AddWithValue("@ProdName", ProdName);
            cmd.Parameters.AddWithValue("@ProdCatID", cateId);
            cmd.Parameters.AddWithValue("@ProdPrice", price);
            cmd.Parameters.AddWithValue("@ProdQty", qty);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd.ExecuteNonQuery();
        }
        public int DeleteProductDAO(int prodID)
        {
            SqlCommand cmd = new SqlCommand("spDeleteProduct", dbCon.GetCon());
            cmd.Parameters.AddWithValue("@ProdID", prodID);
            cmd.CommandType = CommandType.StoredProcedure;
            dbCon.OpenCon();
            return cmd.ExecuteNonQuery();
        }
        
    }
}
