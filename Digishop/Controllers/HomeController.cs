using Digishop.Models;
using Microsoft.AspNetCore.Components.Web;
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
        CategoryContainer categoryContainer = new CategoryContainer(new CategoryDAL()); 
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            
            HomeViewModel hvm = new HomeViewModel();
            
            hvm.products = productContainer.GetTop8product();
            hvm.categories = categoryContainer.GetAllCategories();

            if (HttpContext.Request.QueryString.HasValue && HttpContext.Request.Query["OrderPlaced"].ToString() == "True")
            {
                hvm.showOrderPlacedBox = true;                
            }
            else if(HttpContext.Request.QueryString.HasValue && HttpContext.Request.Query["OrderPlaced"].ToString() == "False")
            {
                hvm.showOrderPlacedBox = false;
            }
            else
            {
                hvm.showOrderPlacedBox = null;
            }

            if(HttpContext.Session.GetInt32("UserID") != null)
            {
                //gebruiker is ingelogd
                hvm.signedIn = true;

                //kijk of de user madmin is
                if (HttpContext.Session.GetInt32("IsAdmin") == 1)
                {
                    hvm.admin = true;
                }
                else
                {
                    hvm.admin = false;
                }
            }
            else
            {
                hvm.signedIn = false;
            }
            return View(hvm);
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