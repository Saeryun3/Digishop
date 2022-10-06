using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopIntertface;

namespace WebshopInterface
{
    public interface IProductContainer
    {      
        void CreateProduct(ProductDTO product); // ask using webinterface
        void DeleteProduct(int productID);
        List<ProductDTO> GetAllProduct();
        DateTime ArchiveProduct(int productID, DateTime dateTime);
    }
}
