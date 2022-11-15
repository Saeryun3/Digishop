using Digishop.Models;
using Microsoft.AspNetCore.Mvc;
using WebshopDAL;
using WebshopLogic;
using WebshopLogic.Helper;

namespace Digishop.Controllers
{
    public class ProductController : Controller
    {
        Product product = new Product();
        ProductContainer productContainer = new ProductContainer(new ProductDAL());
        CategoryContainer categoryContainer = new CategoryContainer(new CategoryDAL()); 
        ProductViewModel productViewModel = new ProductViewModel();
   
        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel pvm)
        {
            if (!productContainer.ExistProduct(pvm.ProductName))
            {
                product.ProductName = pvm.ProductName;
                product.ProductPrice = pvm.ProductPrice;
                product.ProductDescription = pvm.ProductDescription;
                product.ProductImage = pvm.ProductImage;
                product.CategoryID = pvm.CategoryID;
                productContainer.CreateProduct(product);
            }
            else
            {
                ViewBag.Message = "already exist";
            }
            return View(new ProductViewModel(categoryContainer.GetAllCategories()));

        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            ProductViewModel pvm = new ProductViewModel(categoryContainer.GetAllCategories());
            pvm.products = productContainer.GetAllProducts();
            return View(pvm);
        }
    }
}
