using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;
using WebshopLogic.Helper;

namespace WebshopLogic
{
    public class ReviewContainer
    {
        
        private IReviewContainer _ireviewContainer;
        public ReviewContainer(IReviewContainer ireviewcontainer)
        {
            this._ireviewContainer = ireviewcontainer;
        }

        public bool CreateReview(Review review)
        {
            ReviewDTO reviewDTO = ReviewConvertor.ReviewToDTO(review);
            bool result = _ireviewContainer.CreateReview(reviewDTO);
            return result;
        }

        public List<Review> GetAllReviewsForProduct(int productID)
        {
            List<Review> reviews = new List<Review>();
            List<ReviewDTO> reviewDTOs = _ireviewContainer.GetAllReviewsForProduct(productID);
            foreach (ReviewDTO reviewDTO in reviewDTOs)
            {
                reviews.Add(new Review(reviewDTO));
            }
            return reviews;  
        }
        
        //Todo Check review for userid and productid
        public bool CheckIfUserHasProductReviewed(int productID, int userID)
        {
            return _ireviewContainer.CheckIfUserHasProductReviewed(productID, userID);            
        }

        // Todo Delete review
       

    }
}
