using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopLogic;

namespace WebshopTest
{
    [TestClass]
 
    public class ReviewTest
    {
        [TestMethod]
        public void ConstructorReviewTest()
        {
            //arrange
            int reviewID = 1;
            int UserID = 1;
            int productID = 1;
            string Title = "Test Title Review";
            string text = "ervaren product";
            int rating = 5;
            DateTime created = DateTime.Now;
            //act
            var review = new Review(reviewID, UserID, productID, Title, text, rating, created);
            //assert
            Assert.IsTrue(review.ReviewID == reviewID && review.UserID == UserID && review.ProductID == productID && review.Title == Title && review.Text == text && review.Rating == rating && review.Created == created);
        }
    }
}
