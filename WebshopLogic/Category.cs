using WebshopInterface;

namespace WebshopLogic
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public Category(CategoryDTO categoryDTO)
        {
          this.CategoryID = categoryDTO.CategoryID;
          this.CategoryName = categoryDTO.CategoryName;
        }
        public Category()
        {

        }
       //public CategoryDTO toDTO() you can also convert to dto with this function
            //{
            //    return new CategoryDTO(CategoryID, CategoryName);
            //}
    } 
}