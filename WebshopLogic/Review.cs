using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopLogic
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }   

        public Review(ReviewDTO reviewDTO)
        {
            this.ReviewID =  reviewDTO.ReviewID;
            this.UserID = reviewDTO.UserID;
            this.ProductID =  reviewDTO.ProductID;
            this.Title = reviewDTO.Title;
            this.Text = reviewDTO.Text;
            this.Rating = reviewDTO.Rating;
            this.Created = reviewDTO.Created;
        }
        public Review()
        {

        }
        // TODO constructortest

    }
}
