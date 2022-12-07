using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopLogic
{
    public class OrderContainer
    {
        private IOrderContainer _iOrdercontainer;
        public OrderContainer(IOrderContainer iOrdercontainer)
        {
            this._iOrdercontainer = iOrdercontainer;
        }

        public bool SetOrder()
        {
            _iOrdercontainer.SetOrder();
            return true;
        }
    }// in je order zit er adres
    
}
