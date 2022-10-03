using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopIntertface;

namespace WebshopLogic.Helper
{
    public static class CatergoryConvertor
    {
        public static CategoryDTO CatergoryToDTO(Category category)
        {
            return new CategoryDTO(category.CategoryID, category.CategoryName);
        }
    }
}
