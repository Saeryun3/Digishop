using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopInterface
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public double UnitPrice { get; set; }

        public ProductDTO product { get; set; } 

        public OrderDTO(int orderID, int productID, int amount, double unitPrice)
        {
            OrderID = orderID;
            ProductID = productID;
            Amount = amount;
            UnitPrice = unitPrice;
        }
        public OrderDTO()
        {

        }
    }
}
