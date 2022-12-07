using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopLogic;

namespace WebshopTest
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void ConstructorOrderTest()
        {
            //arrange
            int orderID = 1;
            int userID = 1;
            DateTime orderDate = DateTime.Now;
            int orderNumber = 1413199821;
            //act
            var order = new Order(orderID, userID, orderDate, orderNumber);
            //assert
            Assert.IsTrue(order.OrderID == orderID && order.UserID == userID && order.OrderDate == orderDate && order.OrderNumber == orderNumber);
        }
    }
   
}
