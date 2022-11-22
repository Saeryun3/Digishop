using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopInterface
{
    public interface IProductContainer
    {      
        void CreateProduct(ProductDTO product); // ask using webinterface
        List<ProductDTO> GetAllProducts();
        List<ProductDTO> GetTop8product();
        bool ExistProduct(string productName);
        DateTime ArchiveProduct(int productID, DateTime dateTime);
        List<ProductDTO> GetAllProductsByCategoryID(int categoryID);
        ProductDTO GetProductID(int productID);
    }
}
