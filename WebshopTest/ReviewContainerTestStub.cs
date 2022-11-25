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
                Title = "",
                Text = "",
                Rating = 1,
                Created = DateTime.Now,
            };

            ReviewDTO review2 = new ReviewDTO()
            {
                ReviewID = 1,
                ProductID = 1,
                UserID = 1,
                Title = "",
                Text = "",
                Rating = 1,
                Created = DateTime.Now,
            };

            reviews.Add(review1);
            reviews.Add(review2);
        }
        public bool CreateReview(ReviewDTO reviewDTO)
        {
            reviews.Add(reviewDTO);
            return true;
        }

        public bool CheckIfUserHasProductReviewed(int productID, int userID)
        {
            throw new NotImplementedException();
        }

        public List<ReviewDTO> GetAllReviewsForProduct(int productID)
        {
            throw new NotImplementedException();
        }
    }
}
