using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;
using WebshopLogic;

namespace WebshopTest
{
    [TestClass]
    public class ReviewContainerTest
    {
        [TestMethod]
        public void CreateReviewtest()
        {
            //arrange
            ReviewContainerTestStub reviewContainerTestStub = new ReviewContainerTestStub();
            ReviewContainer reviewContainer = new ReviewContainer(reviewContainerTestStub);
            Review review3 = new Review()
            {
                ReviewID = 3,
                ProductID = 1,
                UserID = 3,
                Title = "Review 3",
                Text = "Third review",
                Rating = 2,
                Created = DateTime.Now,
            };
            //act
            reviewContainer.CreateReview(review3);
            //assert
            Assert.AreEqual(review3.ReviewID, reviewContainerTestStub.reviews.Last().ReviewID);
            Assert.AreEqual(review3.ProductID, reviewContainerTestStub.reviews.Last().ProductID);
            Assert.AreEqual(review3.UserID, reviewContainerTestStub.reviews.Last().UserID);
            Assert.AreEqual(review3.Title, reviewContainerTestStub.reviews.Last().Title);
            Assert.AreEqual(review3.Text, reviewContainerTestStub.reviews.Last().Text);
            Assert.AreEqual(review3.Rating, reviewContainerTestStub.reviews.Last().Rating);
            Assert.AreEqual(review3.Created, reviewContainerTestStub.reviews.Last().Created);
        }

        //controleren
        [TestMethod]
        public void CheckIfUserHasProductReviewedTest()
        {
            //arrange
            ReviewContainerTestStub reviewContainerTestStub = new ReviewContainerTestStub();
            ReviewContainer reviewContainer = new ReviewContainer(reviewContainerTestStub);
            Review review1 = new Review()
            {
                ReviewID = 1,
                ProductID = 1,
                UserID = 1,
                Title = "Review 1",
                Text = "First Review",
                Rating = 5,
                Created = DateTime.Now,
            };
            //act
            var reviewed = (reviewContainer.CheckIfUserHasProductReviewed(review1.ProductID, review1.UserID));
            //assert
            Assert.IsTrue(reviewed);
        }
        [TestMethod]
        public void CheckIfUserHasNotProductReviewed()
        {
            //arrange
            ReviewContainerTestStub reviewContainerTestStub = new ReviewContainerTestStub();
            ReviewContainer reviewContainer = new ReviewContainer(reviewContainerTestStub);
            Review review5 = new Review()
            {
                ReviewID = 5,
                ProductID = 1,
                UserID = 3,
                Title = "Review 5",
                Text = "Fifth Review",
                Rating = 4,
                Created = DateTime.Now,
            };
            //act
            var notReviewed = (reviewContainer.CheckIfUserHasProductReviewed(review5.ProductID, review5.UserID));
            //assert
            Assert.IsFalse(notReviewed);
        }
        [TestMethod]
        public void GetAllReviewsForProduct()
        {
            //arrange
            ReviewContainerTestStub reviewContainerTestStub = new ReviewContainerTestStub();
            ReviewContainer reviewContainer = new ReviewContainer(reviewContainerTestStub);
            //act
            List<Review> reviews = reviewContainer.GetAllReviewsForProduct(1);
            //assert
            Assert.AreEqual(reviewContainerTestStub.GetAllReviewsForProduct(1).Count, reviews.Count);
            for (int i = 0; i < reviews.Count; i++)
            {
                
                    Assert.AreEqual(reviews[i].ReviewID, reviewContainerTestStub.reviews[i].ReviewID);
                    Assert.AreEqual(reviews[i].UserID, reviewContainerTestStub.reviews[i].UserID);
                    Assert.AreEqual(reviews[i].ProductID, reviewContainerTestStub.reviews[i].ProductID);
                    Assert.AreEqual(reviews[i].Title, reviewContainerTestStub.reviews[i].Title);
                    Assert.AreEqual(reviews[i].Text, reviewContainerTestStub.reviews[i].Text);
                    Assert.AreEqual(reviews[i].Rating, reviewContainerTestStub.reviews[i].Rating);
                    Assert.AreEqual(reviews[i].Created, reviewContainerTestStub.reviews[i].Created);
                
            }
        }
    }
}
