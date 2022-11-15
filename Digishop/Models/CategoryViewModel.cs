using Microsoft.Build.Framework;
using System.ComponentModel;
using WebshopLogic;

namespace Digishop.Models
{
    public class CategoryViewModel
    {

        public int CategoryID { get; set; }
        [Required]
        [DisplayName("Categorie naam:")]
        public string CategoryName { get; set; }
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }

        public CategoryViewModel(Category category)
        {   if (category == null) return;
            this.CategoryID = category.CategoryID;  
            this.CategoryName = category.CategoryName;
        }
        public CategoryViewModel()
        {

        }
    }
}
