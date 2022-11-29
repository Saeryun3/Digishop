using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopTest
{
    public class CategoryContainterTestStub : ICategoryContainer
    {
        public List<CategoryDTO> categories = new List<CategoryDTO>();
        public CategoryContainterTestStub()
        {
            CategoryDTO category1 = new CategoryDTO()
            {
                CategoryID = 1,
                CategoryName = "Category1"

            };
             CategoryDTO category2 = new CategoryDTO()
             {
                 CategoryID = 2,
                 CategoryName = "Category2"
             };
            categories.Add(category1);
            categories.Add(category2);

        }
        public bool CreateCategory(string categoryname)
        {
            categories.Add(new CategoryDTO(3,categoryname));
            return true;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return categories;
        }

        public bool CategoryExist(string categoryname)
        {
            foreach (CategoryDTO category in categories)
            {
                if (category.CategoryName == categoryname)
                {
                    return true;
                }
            }
            return false;
        }

        // controleren
        public string GetCategoryNameByCategoryID(int categoryID)
        {
            foreach (var categoryDTO in categories)
            {
                if (categoryDTO.CategoryID == categoryID)
                {
                    return categoryDTO.CategoryName;    
                }
            }
            return null;
        }

        public void DeleteCategoryID(int categoryID)
        {
            throw new NotImplementedException();
        }
    }
}
