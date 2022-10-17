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

        public CategoryViewModel(Category category)
        {           
            this.CategoryID = category.CategoryID;  
            this.CategoryName = category.CategoryName;
        }
        public CategoryViewModel()
        {

        }
    }
}
