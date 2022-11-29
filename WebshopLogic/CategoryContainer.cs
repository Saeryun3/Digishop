using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;
using WebshopLogic.Helper;

namespace WebshopLogic
{
    public class CategoryContainer
    {
        private ICategoryContainer _iCategoryContainer;
        public CategoryContainer(ICategoryContainer icategory)
        {
            this._iCategoryContainer = icategory;
        }

        public bool CreateCategory(string categoryname)
        {
           bool result = _iCategoryContainer.CreateCategory(categoryname);
           return result;
            //CategoryDTO categoryDTO = CategoryConvertor.CategoryToDTO(); need one datetype           
        }

        public string GetCategoryNameByCategoryID(int id)
        {
            return _iCategoryContainer.GetCategoryNameByCategoryID(id);
        }
        public List<Category> GetAllCategories()
        {
            List<CategoryDTO> categorieDTOs = _iCategoryContainer.GetAllCategories();
            List<Category> categories = new List<Category>();
            foreach (CategoryDTO categoryDTO in categorieDTOs)
            {
                categories.Add(new Category(categoryDTO));
            }
            return categories;
        }
        public bool CategoryExist(string categoryname)
        {            
            bool result = _iCategoryContainer.CategoryExist(categoryname);
            return result;
        }
        // to do check if category exist
        ///to do delete not sure
        public void DeleteCategoryID(int categoryID)
        {
            _iCategoryContainer.DeleteCategoryID(categoryID);
        }
    }
}
