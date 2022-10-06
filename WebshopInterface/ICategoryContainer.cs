using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopIntertface
{
    public interface ICategoryContainer
    {
        void CreateCategory(CategoryDTO categoryDTO);
        List<CategoryDTO> GetAllCategories();
        void DeleteCategoryID(int categoryID);
    }
}
