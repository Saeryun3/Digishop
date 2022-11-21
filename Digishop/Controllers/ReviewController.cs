using Digishop.Models;
using Microsoft.AspNetCore.Mvc;
using WebshopDAL;
using WebshopLogic;

namespace Digishop.Controllers
{
    public class ReviewController : Controller
    {
        Review review = new Review();
        ReviewContainer reviewContainer = new ReviewContainer(new ReviewDAL());
        [HttpPost]
        public IActionResult CreateReview(ReviewViewModel rvm)
        {
            if (reviewContainer.CheckIfUserHasProductReviewed(rvm.ProductID, rvm.UserID))
            {
                return View();
            }
            review.Created = DateTime.Now;
            review.Title = rvm.Title;
            review.Text = rvm.Text;
            review.Rating = rvm.Rating;
            reviewContainer.CreateReview(review);
            return View();
        }
        [HttpGet]
        public IActionResult CreateReview()
        {
            return View();  
        }
    }
}
