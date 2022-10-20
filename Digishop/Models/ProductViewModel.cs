using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using WebshopInterface;
using WebshopLogic;

namespace Digishop.Models
{
    public class ProductViewModel
    {
        
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public string ProductImage { get; set; }
        public DateTime Delete { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }

        public ProductViewModel(Product product)
        {
            this.ProductID = product.ProductID;
            this.ProductName = product.ProductName;
            this.ProductPrice = product.ProductPrice;
            this.ProductDescription = product.ProductDescription;
            this.ProductImage = product.ProductImage;
            this.Delete = product.Delete;
            this.CategoryID = product.CategoryID;
        }
        public ProductViewModel()
        {

        }

        public ProductViewModel(List<Category> categories)
        {
            this.categories = categories;
        }
    }
}
