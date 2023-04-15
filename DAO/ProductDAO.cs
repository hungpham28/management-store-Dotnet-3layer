using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ProductDAO
    {
        private DBConnect connect = new DBConnect();

        public DataTable SelectAllProductByCatId(int categoryId)
        {
            SqlCommand cmd = new SqlCommand("spGetAllProductList_SearchByCat", connect.GetCon());
            cmd.Parameters.AddWithValue("@ProdCatID", categoryId);
            cmd.CommandType = CommandType.StoredProcedure;
            connect.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.CloseCon();
            return dt;
        }
    }
}
