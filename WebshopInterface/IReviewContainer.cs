using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopInterface
{
    public  interface IReviewContainer
    {
        bool CreateReview(ReviewDTO reviewDTO);
        int GetAllReviewsForProduct(int productID);
    }
}
