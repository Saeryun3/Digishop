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
        List<ProductDTO> GetAllProduct();
        DateTime ArchiveProduct(int productID, DateTime dateTime);
    }
}
