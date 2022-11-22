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
            ReviewDTO review1 = new ReviewDTO()
            {

            };

            ReviewDTO review2 = new ReviewDTO()
            {

            };

            reviews.Add(review1);
            reviews.Add(review2);
        }

        public bool CheckIfUserHasProductReviewed(int productID, int userID)
        {
            throw new NotImplementedException();
        }

        public bool CreateReview(ReviewDTO reviewDTO)
        {
            reviews.Add(reviewDTO);
            return true;
        }

        public List<ReviewDTO> GetAllReviewsForProduct(int productID)
        {
            throw new NotImplementedException();
        }
    }
}
