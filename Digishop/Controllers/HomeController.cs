using Digishop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebshopDAL;
using WebshopLogic;

namespace Digishop.Controllers
{
    public class HomeController : Controller
    {
        //Product product = new Product();
        ProductContainer productContainer = new ProductContainer(new ProductDAL());
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProductViewModel> pvms = new List<ProductViewModel>();
            List<Product> products = productContainer.GetTop8product();
            foreach (Product product in products)
            {
                ProductViewModel pvm = new ProductViewModel();
                pvm.ProductID = product.ProductID;
                pvm.ProductName = product.ProductName;
                pvm.ProductDescription = product.ProductDescription;
                pvm.ProductPrice = product.ProductPrice;
                pvm.ProductImage = product.ProductImage;
                pvm.CategoryID = product.CategoryID;
                pvms.Add(pvm);
            }
            return View(pvms);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}