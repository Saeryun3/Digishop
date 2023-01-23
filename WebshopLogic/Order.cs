using WebshopInterface;

namespace WebshopLogic
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public double UnitPrice { get; set; }
        public Product product  { get; set; }
        public double TotalPrice { get { return GetTotalPrice(); } }

        public Order(OrderDTO orderDTO)
        {
            this.OrderID = orderDTO.OrderID;
            this.ProductID =  orderDTO.ProductID;
            this.Amount = orderDTO.Amount;
            this.UnitPrice = orderDTO.UnitPrice;
        }

        private double GetTotalPrice()
        {
            return Amount * UnitPrice;
        }
        public Order()
        {

        }

        // constructorTest
        public Order(int orderID, int productID, int amount, double unitPrice, Product product)
        {
            OrderID = orderID;
            ProductID = productID;
            Amount = amount;
            UnitPrice = unitPrice;
            this.product = product;
        }

    }
}