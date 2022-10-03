using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopIntertface;
using WebshopLogic.Helper;

namespace WebshopLogic
{
    public class CategoryContainer
    {
        private ICategoryContainer Category;
        public CategoryContainer(ICategoryContainer icategory)
        {
            this.Category = icategory;
        }

        // to do implement functions
        // interface C
        // DAl / convertor
        public void CreateCategory(Category category)
        {
            CategoryDTO categoryDTO = CatergoryConvertor.CatergoryToDTO(category);
            Category category1 = new Category();
            categoryDTO.CategoryName = category1.CategoryName;
        }
        public List<Category> GetAllCategories()
        {
            return new List<Category>();
        }
        ///to do delete
        //public void DeleteCategoryID(int id)
        //{

        //}
    }
}
