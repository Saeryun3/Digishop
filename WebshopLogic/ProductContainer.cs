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
        private IProductContainer _iproductContainer;
            public ProductContainer(IProductContainer iproduct)
            { 
                this._iproductContainer = iproduct;
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
        public List<Product> GetAllProduct()
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            List<Product> products = new List<Product>();
            foreach (ProductDTO productDTO in productDTOs)
            {
                products.Add(new Product(productDTO));
            }
            return products;
        }

        public DateTime ArchiveProduct(int productID)
        {
            DateTime now = DateTime.Now;
            _iproductContainer.ArchiveProduct(productID, now);
            return DateTime.Now;
        }

        //public void DeleteProduct(int productID)
        //{
        //    _iproductContainer.DeleteProduct(productID);
        //}
        //to do
        //public List<_iproductContaier> GetAllProductByCategory(string category)
        //{
        //    return GetAllProduct();
        //}
    }
}
