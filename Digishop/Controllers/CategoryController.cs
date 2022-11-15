using Digishop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebshopDAL;
using WebshopLogic;

namespace Digishop.Controllers
{
    public class CategoryController : Controller
    {
        CategoryContainer categoryContainer = new CategoryContainer(new CategoryDAL());
        ProductContainer productContainer = new ProductContainer(new ProductDAL()); 
        CategoryViewModel cvm = new CategoryViewModel();

        public IActionResult Index(int categoryID)
        {
            cvm.products = productContainer.GetAllProductsByCategoryID(categoryID);
            cvm.CategoryName = categoryContainer.GetCategoryNameByCategoryID(categoryID);
            cvm.categories = categoryContainer.GetAllCategories();
          //  cvm.products = ProductContainer
            return View(cvm);
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel cvm)
        {
            if (!categoryContainer.CategoryExist(cvm.CategoryName))
            {
                var createcategory = categoryContainer.CreateCategory(cvm.CategoryName);
            }
            else
            {
                ViewBag.Message = "already exist";

            }
            return View(new CategoryViewModel()
            {
                categories = categoryContainer.GetAllCategories()
            });

        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View(new CategoryViewModel(null)
            {
                categories = categoryContainer.GetAllCategories()
            });
        }

    }
}
