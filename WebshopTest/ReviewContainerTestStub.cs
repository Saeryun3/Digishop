using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopTest
{
    public class ReviewContainerTestStub : IReviewContainer
    {
        public List<ReviewDTO> reviews = new List<ReviewDTO>();
        public ReviewContainerTestStub()
        {
            // change 
            ReviewDTO review1 = new ReviewDTO()
            {
                ReviewID = 1,
                ProductID = 1,
                UserID = 1,
                Title = "Review 1",
                Text = "First Review",
                Rating = 5,
                Created = DateTime.Now,
            };

            ReviewDTO review2 = new ReviewDTO()
            {
                ReviewID = 2,
                ProductID = 1,
                UserID = 2,
                Title = "Review 2",
                Text = "Second Review",
                Rating = 3,
                Created = DateTime.Now,
            };

            ReviewDTO review3 = new ReviewDTO()
            {
                ReviewID = 3,
                ProductID = 2,
                UserID = 1,
                Title = "Review 3",
                Text = "Second Review",
                Rating = 1,
                Created = DateTime.Now,
            };

            ReviewDTO review4 = new ReviewDTO()
            {
                ReviewID = 4,
                ProductID = 2,
                UserID = 2,
                Title = "Review 3",
                Text = "Third Review",
                Rating = 5,
                Created = DateTime.Now,
            };

            reviews.Add(review1);
            reviews.Add(review2);
            reviews.Add(review3);
            reviews.Add(review4);
        }
        public bool CreateReview(ReviewDTO reviewDTO)
        {
            reviews.Add(reviewDTO);
            return true;
        }
        // controleren vanaf hier
        public bool CheckIfUserHasProductReviewed(int productID, int userID)
        {
            foreach (var review in reviews)
            {
                if (review.UserID == userID && review.ProductID == productID)
                {
                    return true;
                }
            }
            return false;
          //  return reviews.Any(a => a.UserID == userID && a.ProductID == productID);
        }

        public List<ReviewDTO> GetAllReviewsForProduct(int productID)
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>();
            foreach (ReviewDTO reviewDTOs in reviews)
            {
                if (reviewDTOs.ProductID == productID)
                {
                    reviews.Add(reviewDTOs);
                }
            }
            return reviews;
            //return reviews.Where(a => a.ProductID == productID).ToList();
        }
        //to do delete
    }
}
