using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopInterface
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public DateTime Delete { get; set; }
        public int CategoryID { get; set; }

        public ProductDTO(int productID, string productName, double productPrice, string productDescription, string productImage, DateTime delete, int categoryID)
        {
            ProductID = productID; ;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductDescription = productDescription;
            ProductImage = productImage;
            Delete = delete;
            CategoryID = categoryID;
        }

        public ProductDTO()
        {
        }
    }
}
