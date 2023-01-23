using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopInterface
{
    public interface IOrderContainer
    {
        List<OrderDTO> GetCartProducts(string CartID);
        OrderDTO GetCartProduct(string CartID, int ProductID);
        bool AddToCart(string CartID, int ProductID, int Amount, double UnitPrice);
        bool UpdateCart(string CartID, int ProductID, int Amount);
        bool DeleteFromCart(string CartID, int ProductID);
        bool PlaceOrder(int userID, string CartID);
    }
}
