using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ProductBUS
    {
        private ProductDAO productDAO=new ProductDAO();
        public DataTable SelectAllProduct()
        {
            return productDAO.selectAllProduct();
        }
        public bool CheckDuplicateProduct(string productName, int productCatID)
        {
            return productDAO.CheckDuplicateProductDAO(productName, productCatID);
        }
        public bool InsertProduct(string ProdName, int cateId, decimal price, int qty)
        {
            return productDAO.InsertProductDAO(ProdName, cateId, price, qty) > 0;
        }
        public bool UpdateProduct(string ProdName, int cateId, decimal price, int qty)
        {
            return productDAO.UpdateProductDAO(ProdName, cateId, price, qty) > 0;
        }
        public bool DeleteProduct(int ProdID)
        {
            return productDAO.DeleteProductDAO(ProdID) > 0;
        }
        public DataTable GetAllProductList_SearchByCat(int id)
        {
            return productDAO.GetAllProductList_SearchByCatDAO(id);
        }
    }
}
