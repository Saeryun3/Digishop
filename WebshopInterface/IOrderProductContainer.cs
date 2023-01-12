using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopInterface
{
    public interface IOrderProductContainer
    {
        ProductDTO GetProduct(int productID);
    }
}
