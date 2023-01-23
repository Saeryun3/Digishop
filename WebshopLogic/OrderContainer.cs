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
        public List<Order> GetCartProducts(string CartID)
        {
            List<OrderDTO> orderProductsDTO = _iOrdercontainer.GetCartProducts(CartID);
            List<Order> orderProducts = new List<Order>();

            foreach (OrderDTO orderProductDTO in orderProductsDTO)
            {
                orderProducts.Add(new Order(orderProductDTO)
                {
                    product = new Product(_productDAL.GetProductID(orderProductDTO.ProductID))
                });
            }

            return orderProducts;
        }

        public Order GetCartProduct(string CartID, int ProductID)
        {

            return new Order(_iOrdercontainer.GetCartProduct(CartID, ProductID));
        }


        //public Double GetCartTotal(string CartID)
        //{
        //    Double sum = 0;

        //    List<OrderDTO> cartProducts = _iOrdercontainer.GetCartProducts(CartID);

        //    foreach (OrderDTO cartProduct in cartProducts)
        //    {
        //        sum += cartProduct.Amount * cartProduct.UnitPrice;
        //    }

        //    return sum;
        //}

        public bool AddToCart(string CartID, int ProductID, int Amount, double UnitPrice)
        {
            Order cartProduct = new Order(_iOrdercontainer.GetCartProduct(CartID, ProductID));

            if (cartProduct.ProductID == 0)
            {
                return _iOrdercontainer.AddToCart(CartID, ProductID, Amount, UnitPrice);
            }
            else
            {             
                return _iOrdercontainer.UpdateCart(CartID, ProductID, Amount);
            }
        }


        public bool DeleteItemFromCart(string CartID, int ProductID)
        {
            //kijk of de amount groter is dan 1
            OrderDTO orderProduct = _iOrdercontainer.GetCartProduct(CartID, ProductID);

            if (orderProduct.Amount > 1)
            {
                return _iOrdercontainer.UpdateCart(CartID, ProductID, -1);
            }
            else
                return _iOrdercontainer.DeleteFromCart(CartID, ProductID);
        }

        public bool AddProductAmountToCart(string CartID, int ProductID)
        {
            OrderDTO orderProduct = _iOrdercontainer.GetCartProduct(CartID, ProductID);

            return _iOrdercontainer.UpdateCart(CartID, ProductID, 1);
        }

        public bool PlaceOrder(int userID, string CartID)
        {
            return _iOrdercontainer.PlaceOrder(userID, CartID);
        }
    }
}
