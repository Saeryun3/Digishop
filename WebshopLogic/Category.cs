using WebshopIntertface;

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
            //public CategoryDTO toDTO()
            //{
            //    return new CategoryDTO(CategoryID, CategoryName);
            //}
        public Category()
        {

        }
    } 
}