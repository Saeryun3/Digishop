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
                CategoryID = 1,
            };

            ProductDTO product3 = new ProductDTO()
            {
                ProductID = 3,
                ProductName = "Product three",
                ProductPrice = 19.99,
                ProductDescription = "Product three is the newest",
                ProductImage = "TestsProduct.PNG",
                CategoryID = 1,
            };

            ProductDTO product4 = new ProductDTO()
            {
                ProductID = 4,
                ProductName = "Product four",
                ProductPrice = 29.99,
                ProductDescription = "Product four is the newest one",
                ProductImage = "TestsssProduct.PNG",
                CategoryID = 1,
            };

            ProductDTO product5 = new ProductDTO()
            {
                ProductID = 5,
                ProductName = "Product five",
                ProductPrice = 49.99,
                ProductDescription = "Product five is the newest one",
                ProductImage = "TtttestProduct.PNG",
                CategoryID = 1,
            };

            ProductDTO product6 = new ProductDTO()
            {
                ProductID = 6,
                ProductName = "Product six",
                ProductPrice = 39.99,
                ProductDescription = "Product six is the newest one",
                ProductImage = "TeeeestProduct.PNG",
                CategoryID = 2,
            };

            ProductDTO product7 = new ProductDTO()
            {
                ProductID = 7,
                ProductName = "Product seven",
                ProductPrice = 59.99,
                ProductDescription = "Product five is the newest one",
                ProductImage = "TestpppppProduct.PNG",
                CategoryID = 2,
            };

            ProductDTO product8 = new ProductDTO()
            {
                ProductID = 8,
                ProductName = "Product eight",
                ProductPrice = 79.99,
                ProductDescription = "Product eight is the newest one",
                ProductImage = "TestProoooduct.PNG",
                CategoryID = 2,
            };
            ProductDTO product9 = new ProductDTO()
            {
                ProductID = 9,
                ProductName = "Product nine",
                ProductPrice = 89.99,
                ProductDescription = "Product nine is the newest one",
                ProductImage = "TestProduuuuct.PNG",
                CategoryID = 2,
            };

            ProductDTO product10 = new ProductDTO()
            {
                ProductID = 10,
                ProductName = "Product ten",
                ProductPrice = 99.99,
                ProductDescription = "Product ten is the newest one",
                ProductImage = "TestProduuuuccct.PNG",
                CategoryID = 1,
            };


            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
            products.Add(product6);
            products.Add(product7);
            products.Add(product8);
            products.Add(product9);
            products.Add(product10);
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
            List<ProductDTO> prods = new List<ProductDTO>();
            foreach (ProductDTO productDTOs in products)
            {
                if (productDTOs.CategoryID == categoryID)
                {
                    prods.Add(productDTOs);
                }
            }
            return prods;
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
            products.Take(8);

            return products;
            // return prods.GetRange(0, 8);         
        }

        public DateTime ArchiveProduct(int productID, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public bool UnarchiveProduct(int productID)
        {
            throw new NotImplementedException();
        }
    }
}
