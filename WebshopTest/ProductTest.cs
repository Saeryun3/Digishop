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
    public class ProductTest
    {
        [TestMethod]
        public void ConstructorProductTest()
        {
            //arrange
            int productID = 1;
            string productName = "TestProduct";
            double productprice = 199.99;
            string productDescription = "TestBeschrijving";
            string productImage = "Test.PNG";
            DateTime delete = new DateTime(2022, 12, 13);
            int categoryID = 5;
            //act
            var product = new Product(productID, productName, productprice, productDescription, productImage, delete, categoryID);
            //assert
            //Assert.AreEqual(productID, productID);
            Assert.IsTrue(product.ProductID == productID && product.ProductName == productName && product.ProductPrice == productprice && product.ProductDescription == productDescription && product.ProductImage == productImage && product.Delete == delete && product.CategoryID == categoryID);
        }
    }
}
