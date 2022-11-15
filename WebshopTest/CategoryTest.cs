using WebshopLogic;

namespace WebshopTest
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void ConstructorCategoryTest()
        {
            //arrange
            int categoryID = 1;
            string categoryName = "TestName";
            //act
            var category = new Category(categoryID, categoryName);
            //assert
            Assert.IsTrue(category.CategoryID == categoryID && category.CategoryName == categoryName);
        }
    }
}