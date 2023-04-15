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
    public class CategoryBUS
    {
        private CategoryDAO categoryDAO = new CategoryDAO();
        public DataTable getAllCategory()
        {
            return categoryDAO.SelectAll();
        }
        public DataTable getrlCategory()
        {
            return categoryDAO.rlCategory();
        }
        public bool IsExistCategoryName(string categoryName,int Id)
        {
            return categoryDAO.existCategory(categoryName,Id) != null;
        }
        public bool IsExistCategoryName(string categoryName)
        {
            return categoryDAO.existCategory(categoryName) != null;
        }
        public DataTable spGetCategory()
        {
            return categoryDAO.spGetCategory();
        }
        public bool Add(CategoryDTO Category)
        {
            return categoryDAO.Insert(Category.categoryName,Category.categoryDesc) > 0;
        }
        public bool Update(CategoryDTO Category)
        {
            return categoryDAO.Update(Category.catId, Category.categoryName, Category.categoryDesc) > 0;
        }
        public bool DeleteById(int id)
        {
            return categoryDAO.Delete(id) > 0;
        }
    }
}
