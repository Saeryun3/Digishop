using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;
using WebshopIntertface;

namespace WebshopLogic
{
    public class ProductContainer
    {
        private IProductContainer Product;
            public CategoryContainer(IProductContainer iproduct)
        {
            this.Product = iproduct;
        }
        public void CreateProduct(Product product)
        {
            ProductDTO productDTO = 
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
