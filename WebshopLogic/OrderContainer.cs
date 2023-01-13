using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopDAL;
using WebshopInterface;

namespace WebshopLogic
{
    public class OrderContainer
    {
        private IOrderContainer _iOrdercontainer;
        private ProductDAL _productDAL;

        public OrderContainer(IOrderContainer iOrdercontainer)
        {
            this._iOrdercontainer = iOrdercontainer;
            this._productDAL = new ProductDAL();
        }

        public bool SetOrder()
        {
            _iOrdercontainer.SetOrder();
            return true;
        }

        public List<OrderProduct> GetCartProducts(string CartID)
        {
            List<OrderProductDTO> orderProductsDTO = _iOrdercontainer.GetCartProducts(CartID);
            List<OrderProduct> orderProducts = new List<OrderProduct>();

            foreach (OrderProductDTO orderProductDTO in orderProductsDTO)
            {
                orderProducts.Add(new OrderProduct(orderProductDTO)
                {
                    product = new Product(_productDAL.GetProductID(orderProductDTO.ProductID))
                });
            }

            return orderProducts;
        }

        public OrderProduct GetCartProduct(string CartID, int ProductID)
        {

            return new OrderProduct(_iOrdercontainer.GetCartProduct(CartID, ProductID));
        }


        public Double GetCartTotal(string CartID)
        {
            Double sum = 0;

            List<OrderProductDTO> cartProducts = _iOrdercontainer.GetCartProducts(CartID);

            foreach (OrderProductDTO cartProduct in cartProducts)
            {
                sum += cartProduct.Amount * cartProduct.UnitPrice;
            }

            return sum;
        }

        public bool AddToCart(string CartID, int ProductID, int Amount, double UnitPrice)
        {
            OrderProduct cartProduct = new OrderProduct(_iOrdercontainer.GetCartProduct(CartID, ProductID));

            if (cartProduct.ProductID > 0)
            {
                if ((cartProduct.Amount + Amount) == 0)
                {
                    return _iOrdercontainer.DeleteFromCart(CartID, ProductID);

                }
                return _iOrdercontainer.UpdateCart(CartID, ProductID, Amount);

            }

            return _iOrdercontainer.AddToCart(CartID, ProductID, Amount, UnitPrice);
        }


        public bool DeleteItemFromCart(string CartID, int ProductID)
        {
            //kijk of de amount groter is dan 1
            OrderProductDTO orderProduct = _iOrdercontainer.GetCartProduct(CartID, ProductID);

            if(orderProduct.Amount > 1)
            {
                return _iOrdercontainer.UpdateCart(CartID, ProductID, -1);
            }
            else
                return _iOrdercontainer.DeleteFromCart(CartID, ProductID);
        }

        public bool AddProductAmountToCart(string CartID, int ProductID)
        {
            OrderProductDTO orderProduct = _iOrdercontainer.GetCartProduct(CartID, ProductID);

            return _iOrdercontainer.UpdateCart(CartID, ProductID, 1);
        }

        public bool PlaceOrder(int userID, string CartID)
        {
            return _iOrdercontainer.PlaceOrder(userID, CartID);
        }


    }// in je order zit er adres

}
