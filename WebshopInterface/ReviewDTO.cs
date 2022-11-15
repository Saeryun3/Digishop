using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopInterface
{
    public class ReviewDTO
    {       
        
            public int ReviewID { get; set; }
            public int UserID { get; set; }
            public int ProductID { get; set; }
            public string Title { get; set; }
            public string Text { get; set; }
            public int Rating { get; set; }
            public DateTime Created { get; set; }

            public ReviewDTO(int reviewID, int userID, int productID, string title, string text, int rating, DateTime created)
            {
                ReviewID = reviewID;
                UserID = userID;
                ProductID = productID;
                Title = title;
                Text = text;
                Rating = rating;
                Created = created;
            }
            public ReviewDTO()
            {

            }        
    }
}
