using Digishop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebshopDAL;
using WebshopLogic;

namespace Digishop.Controllers
{
    public class CategoryController : Controller
    {
        Category category = new Category();
        CategoryContainer categoryContainer = new CategoryContainer(new CategoryDAL());
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel cvm)
        {           
            category.CategoryName = cvm.CategoryName;
            var createcategory = categoryContainer.CreateCategory(category.CategoryName);

            return RedirectToAction("Createcategory", "Category");
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
    }
}
