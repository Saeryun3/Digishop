using WebshopInterface;

namespace WebshopLogic
{
    public class OrderProduct
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public double UnitPrice { get; set; }
        public Product product  { get; set; }
        public double TotalPrice { get { return GetTotalPrice(); } }

        public OrderProduct(OrderProductDTO orderProductDTO)
        {
            this.OrderID = orderProductDTO.OrderID;
            this.ProductID =  orderProductDTO.ProductID;
            this.Amount = orderProductDTO.Amount;
            this.UnitPrice = orderProductDTO.UnitPrice;
        }

        private double GetTotalPrice()
        {
            return Amount * UnitPrice;
        }
        public OrderProduct()
        {

        }
    }
}