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
                CategoryID = 1,
            };

            ProductDTO product2 = new ProductDTO()
            {
                ProductID = 2,
                ProductName = "Product Two",
                ProductPrice = 39.99,
                ProductDescription = "Product Two is the newest one",
                ProductImage = "TestProduct.PNG",
                CategoryID = 2,
            };

            // 6 producten toevoegen
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
        // controleren vanaf hier
        public List<ProductDTO> GetAllProductsByCategoryID(int categoryID)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            foreach (ProductDTO productDTO in products)
            {
                if (productDTO.CategoryID == categoryID)
                {
                    products.Add(productDTO);
                }
            }
            return products;
        }
        public ProductDTO GetProductID(int productID)
        {
            foreach (ProductDTO productDTO in products)
            {
                if (productDTO.ProductID == productID)
                {
                    return productDTO;
                }
            }
            return null;
        }
        // niet zeker en test nu 2
        public List<ProductDTO> GetTop8product()
        {
            return products.GetRange(0,8);
        }

        public DateTime ArchiveProduct(int productID, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
