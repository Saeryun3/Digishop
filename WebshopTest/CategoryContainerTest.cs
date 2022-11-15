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
            int expectedID = categoryContainterTestStub.categories.Count + 1;
            string category = "Category3";

            //act
            categoryContainer.CreateCategory(category);
            //assert
            Assert.AreEqual(category, categoryContainterTestStub.categories.Last().CategoryName);
            Assert.AreEqual(expectedID, categoryContainterTestStub.categories.Last().CategoryID);
        }
        [TestMethod]
        public void TestCategoryExist()
        {
            //arrange
            CategoryContainterTestStub categoryContainterTestStub = new CategoryContainterTestStub();
            CategoryContainer categoryContainer = new CategoryContainer(categoryContainterTestStub);
            string categoryname = "Category2";
            //act
            var actual = categoryContainer.CategoryExist(categoryname);
            //assert
            Assert.IsTrue(actual);

        }
        [TestMethod]
        public void TestCategoryNotExist()
        {
            //arrange
            CategoryContainterTestStub categoryContainterTestStub = new CategoryContainterTestStub();
            CategoryContainer categoryContainer = new CategoryContainer(categoryContainterTestStub);
            string categoryname = "Category3";
            //act
            var actual = categoryContainer.CategoryExist(categoryname);
            //assert
            Assert.IsFalse(actual);

        }
        [TestMethod]
        public void TestGetAllCategories()
        {
            //arrange
            CategoryContainterTestStub categoryContainterTestStub = new CategoryContainterTestStub();
            CategoryContainer categoryContainer = new CategoryContainer(categoryContainterTestStub);
            //act
            List<Category> categories = categoryContainer.GetAllCategories();
            //assert
            Assert.AreEqual(categoryContainterTestStub.GetAllCategories().Count, categories.Count);
            Assert.AreEqual(categories[0].CategoryName, "Category1");
            Assert.AreEqual(categories[0].CategoryID, 1);
            Assert.AreEqual(categories[1].CategoryName, "Category2");
            Assert.AreEqual(categories[1].CategoryID, 2);// vairabele aanmaken 
        }
    }
    
}
