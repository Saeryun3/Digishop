using WebshopLogic;

namespace WebshopTest
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void CreateCategoryTest()
        {
            //arrange
            int categoryID = 1;
            var categoryName = "TestName";
            //act
            var category = new Category(categoryID, categoryName);
            //assert
            Assert.IsTrue(category.CategoryID == categoryID && category.CategoryName == categoryName);
        }
    }
}