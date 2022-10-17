using Digishop.Models;
using Microsoft.AspNetCore.Mvc;
using WebshopDAL;
using WebshopLogic;

namespace Digishop.Controllers
{
    public class ProductController : Controller
    {
        Product product = new Product();
        ProductContainer productContainer = new ProductContainer(new ProductDAL());
        CategoryContainer categoryContainer = new CategoryContainer(new CategoryDAL()); 
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel pvm)
        {
            product.ProductName = pvm.ProductName;
            product.ProductPrice = pvm.ProductPrice;
            product.ProductDescription = pvm.ProductDescription;
            product.ProductImage = pvm.ProductImage;
            product.CategoryID = pvm.CategoryID;
            productContainer.CreateProduct(product);
            return RedirectToAction("CreateProduct", "Product");
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View (new ProductViewModel(categoryContainer.GetAllCategories()));
        }
    }
}
