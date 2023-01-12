using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopLogic
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public string CartID { get; set; }

        public Order(OrderDTO orderDTO)
        {
            this.OrderID = orderDTO.OrderID;
            this.UserID = orderDTO.UserID;
            this.OrderDate = orderDTO.OrderDate;
            this.OrderNumber = orderDTO.OrderNumber;
        }

        //constructortest
        public Order(int orderID, int userID, DateTime orderDate, int orderNumber)
        {
            OrderID = orderID;
            UserID = userID;
            OrderDate = orderDate;
            OrderNumber = orderNumber;
        }
    }
}
