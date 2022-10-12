using Digishop.Models;
using Microsoft.AspNetCore.Mvc;
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
            var createcategory = categoryContainer.CreateCategory(cvm.CategoryName);
            category.CategoryID = cvm.CategoryID;
            category.CategoryName = cvm.CategoryName;
            categoryContainer.CreateCategory(category.CategoryName);
            return RedirectToAction("Index", "home");
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
    }
}
