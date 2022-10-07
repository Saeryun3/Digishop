﻿using System;
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
        private ICategoryContainer _iCategoryContainer;
        public CategoryContainer(ICategoryContainer icategory)
        {
            this._iCategoryContainer = icategory;
        }

        public void CreateCategory(Category category)
        {
            CategoryDTO categoryDTO = CatergoryConvertor.CatergoryToDTO(category);
            _iCategoryContainer.CreateCategory(categoryDTO);
            //Container category1 = new Container(); wrong
            //categoryDTO.CategoryName = category1.CategoryName; wrong
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
        ///to do delete not sure
        public void DeleteCategoryID(int categoryID)
        {
            _iCategoryContainer.DeleteCategoryID(categoryID);
        }
    }
}
