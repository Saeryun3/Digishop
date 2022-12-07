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
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public OrderDTO(int orderID, int userID, DateTime orderDate, int orderNumber)
        {
            OrderID = orderID;
            UserID = userID;
            OrderDate = orderDate;
            OrderNumber = orderNumber;
        }       
        
        public OrderDTO()
        {

        }
    }
}
