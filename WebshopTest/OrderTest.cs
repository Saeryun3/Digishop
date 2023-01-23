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
            int productID = 1;
            int amount = 5;
            double unitPrice = 3.99;
            Product product = new Product();            
            //act
            var order = new Order(orderID, productID, amount, unitPrice, product);
            //assert
            Assert.IsTrue(order.OrderID == orderID && order.ProductID == productID && order.Amount == amount && order.UnitPrice == unitPrice && order.product == product);
        }
    }
   
}
