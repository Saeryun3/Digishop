using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;
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
            _iproductContainer.CreateProduct(productDTO); 
        }
        public List<Product> GetAllProducts()
        {
            List<ProductDTO> productDTOs = _iproductContainer.GetAllProducts();
            List<Product> products = new List<Product>();
            foreach (ProductDTO productDTO in productDTOs)
            {
                products.Add(new Product(productDTO));
            }
            return products;
        }
        public List<Product> GetTop8product()
        {
            List<ProductDTO> productDTOs = _iproductContainer.GetTop8product();
            List<Product> products = new List<Product>();
            foreach (ProductDTO productDTO in productDTOs)
            {
                products.Add(new Product(productDTO));
            }
            return products;
        }
        public bool ExistProduct(string productName)
        {
            bool result = _iproductContainer.ExistProduct(productName);
            return result;
        }

        public DateTime ArchiveProduct(int productID)
        {
            DateTime now = DateTime.Now;
            _iproductContainer.ArchiveProduct(productID, now);
            return DateTime.Now;
        }

        public List<Product> GetAllProductsByCategoryID(int categoryID)
        {
            List<ProductDTO> productDTOs = _iproductContainer.GetAllProductsByCategoryID(categoryID);
            List<Product> products = new List<Product>();
            foreach (ProductDTO productDTO in productDTOs)
            {
                products.Add(new Product(productDTO));
            }
            return products;
        }
        // to do: check if product exist
        //public void DeleteProduct(int productID)
        //{
        //    _iproductContainer.DeleteProduct(productID);
        //}
        //to do
        //public List<_iproductContaier> GetAllProductByCategory(string category)
        //{
        //    return GetAllProducts();
        //}
    }
}
