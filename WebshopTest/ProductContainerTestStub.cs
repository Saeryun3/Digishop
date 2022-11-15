using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopTest
{
    public class ProductContainerTestStub : IProductContainer
    {
        public List<ProductDTO> products = new List<ProductDTO>();
        public ProductContainerTestStub()
        {
            ProductDTO product1 = new ProductDTO()
            {
                ProductID = 1,
                ProductName = "Product One",
                ProductPrice = 19.99,
                ProductDescription = "Product One is first version",
                ProductImage = "Product.PNG",
                Delete = DateTime.Now,
                CategoryID = 1,
            };

            ProductDTO product2 = new ProductDTO()
            {
                ProductID = 2,
                ProductName = "Product Two",
                ProductPrice = 39.99,
                ProductDescription = "Product Two is the newest one",
                ProductImage = "TestProduct.PNG",
                Delete = DateTime.Now,
                CategoryID = 2,
            };
            products.Add(product1);
            products.Add(product2);
        }

        public void CreateProduct(ProductDTO product)
        {
            products.Add(product);
        }

        public bool ExistProduct(string productName)
        {
            foreach (ProductDTO product in products)
            {
                if (product.ProductName == productName)
                {
                    return true;
                }
            }
            return false;
        }

        public List<ProductDTO> GetAllProducts()
        {
            return products;
        }

        public List<ProductDTO> GetAllProductsByCategoryID(int categoryID)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetTop8product()
        {
            throw new NotImplementedException();
        }
        public DateTime ArchiveProduct(int productID, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
