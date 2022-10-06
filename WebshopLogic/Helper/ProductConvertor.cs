using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopIntertface;

namespace WebshopLogic.Helper
{
    public static class ProductConvertor
    {
        public static ProductDTO ProductToDTO(Product product)
        {
            return new ProductDTO(product.ProductID, product.ProductName, product.ProductPrice, product.ProductDescription, product.ProductImage, product.Delete, product.CategoryID);
        }
    }
}
