using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopLogic.Helper
{
    public static class ReviewConvertor
    {
        public static ReviewDTO ReviewToDTO(Review review)
        {
            return new ReviewDTO(review.ReviewID, review.UserID, review.ProductID, review.Title, review.Text, review.Rating, review.Created);
        }
    }
}
