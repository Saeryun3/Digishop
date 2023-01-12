using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopLogic
{
    public class OrderProductContainer
    {
        private IOrderProductContainer _iorderProductContainer;
        public OrderProductContainer(IOrderProductContainer IorderProductContainer)
        {
            this._iorderProductContainer = IorderProductContainer;
        }
        public Product GetProduct(int productID)
        {
            return new Product(_iorderProductContainer.GetProduct(productID));
        }
    }
}
