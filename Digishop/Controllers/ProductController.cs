using Digishop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Runtime.CompilerServices;
using WebshopDAL;
using WebshopInterface;
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
        ReviewContainer reviewContainer = new ReviewContainer(new ReviewDAL());
        Review review = new Review();   

        public IActionResult Index(int id)
        {
            Product product = productContainer.GetProductID(id);
            ProductViewModel pvm = new ProductViewModel(product);

            return View(pvm);
        }

        [HttpPost]
        public IActionResult Index(ProductViewModel pvm)
        {
            if (reviewContainer.CheckIfUserHasProductReviewed(pvm.ProductID, Convert.ToInt32(HttpContext.Session.GetInt32("UserID"))))
            {
                return View(pvm);
            }
            review.Created = DateTime.Now;
            review.Title = pvm.reviewTitle;
            review.Text = pvm.reviewString;
            review.ProductID = pvm.ProductID;
            review.UserID = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            reviewContainer.CreateReview(review);
            return View();
        }

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
            return RedirectToAction("CreateProduct"); 

        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            ProductViewModel pvm = new ProductViewModel(categoryContainer.GetAllCategories());
            pvm.products = productContainer.GetAllProducts();
            //pvm.Delete = productContainer.ArchiveProduct(product.ProductID);

            
            return View(pvm);
        }
        [HttpPost]
        public IActionResult ArchiveProduct(ProductViewModel pvm)
        {
            productContainer.ArchiveProduct(pvm.ProductID);
            return RedirectToAction(nameof(CreateProduct));
        }

        [HttpGet]
        public IActionResult ArchiveProduct(int id )
        {
            product = productContainer.GetProductID(id);
            productViewModel = new ProductViewModel(product);
            return View (productViewModel);
        }
        [HttpPost]
        public IActionResult UnarchiveProduct(ProductViewModel pvm)
        {
            productContainer.UnarchiveProduct(pvm.ProductID);
            return RedirectToAction(nameof(CreateProduct));
        }
        [HttpGet]
        public IActionResult UnarchiveProduct(int id)
        {
            product = productContainer.GetProductID(id);
            productViewModel = new ProductViewModel(product);
            return View(productViewModel);
        }
    }
}
