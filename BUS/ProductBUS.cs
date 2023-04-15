using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ProductBUS
    {
        private ProductDAO productDAO = new ProductDAO();

        public DataTable getAllProductByCategory(int catID)
        {
            return productDAO.SelectAllProductByCatId(catID);
        }

    }
}
