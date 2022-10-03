using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopIntertface;

namespace WebshopLogic
{
    public class Product
    {     
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }

        public Product(ProductDTO productDTO)
        {
            this.ProductID = productDTO.ProductID;
            this.ProductName = productDTO.ProductName;
            this.ProductPrice = productDTO.ProductPrice;
            this.ProductDescription = productDTO.ProductDescription;
            this.ProductImage = productDTO.ProductImage;
        }

    }
}
