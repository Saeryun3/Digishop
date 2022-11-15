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
        // To Do: create delete get reviews for specific product. dependecy injection
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

        public int GetAllReviewsForProduct(int productID)
        {
            return _ireviewContainer.GetAllReviewsForProduct(productID);
        }

    }
}
