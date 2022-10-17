using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopLogic.Helper
{
    public static class CategoryConvertor
    {
        public static CategoryDTO CategoryToDTO(Category category)// let op spelling
        {
            return new CategoryDTO(category.CategoryID, category.CategoryName);
        }
    }
}
