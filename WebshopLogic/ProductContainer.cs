using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;
using WebshopIntertface;
using WebshopLogic.Helper;

namespace WebshopLogic
{
    public class ProductContainer
    {
        private IProductContainer Product;
            public ProductContainer(IProductContainer iproduct)
            { 
                this.Product = iproduct;
            }
        public void CreateProduct(Product product)
        {
            ProductDTO productDTO = ProductConvertor.ProductToDTO(product);
            Product product1 = new Product(productDTO);
            productDTO.ProductName = product1.ProductName;
            productDTO.ProductDescription = product1.ProductDescription;
            productDTO.ProductPrice = product1.ProductPrice; 
            productDTO.ProductImage = product1.ProductImage;    

        }

        public void DeleteProduct(int productID)
        {
            Product.DeleteProduct(productID);
        }
        public List<Product> GetAllProduct()
        {
            List<Product> products = new List<Product>();
            return products;
        }
        public List<Product> GetAllProductByCategory(string category)
        {
            return GetAllProduct();
        }
    }
}
