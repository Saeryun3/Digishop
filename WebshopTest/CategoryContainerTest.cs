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
    public class CategoryContainerTest
    {
        [TestMethod]
        public void TestCreateCategory()
        {
            //arrange
            CategoryContainterTestStub categoryContainterTestStub = new CategoryContainterTestStub();
            CategoryContainer categoryContainer = new CategoryContainer(categoryContainterTestStub);
            Category category = new Category()
            {
                CategoryID = 3,
                CategoryName = "Category3",
            };
            var expectedamount = categoryContainterTestStub.categories.Count + 1;
            //act
            categoryContainer.CreateCategory(categoryname);
            //assert
            Assert.AreEqual
        }
    }
    
}
