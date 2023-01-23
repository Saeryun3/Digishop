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
    public class UserTest
    {
        [TestMethod]
        public void ConstructorUserTest()
        {
            //arrange
            int userID = 1;
            string email = "Sam@hotmail.com";
            string password = "1234";
            bool isAdmin = false;
            string firstName = "Sam";
            string lastName = "Dag";
            string phoneNumber = "0644335690";
            string address = "steenmanslaan";
            string houseNumber = "10A";
            string postalCode = "4030AB";
            string city = "Eindhoven";
            //act
            var user = new User(userID, email, password, isAdmin, firstName, lastName, phoneNumber, address, houseNumber, postalCode, city);
            //assert
            Assert.IsTrue(user.UserID == userID && user.Email == email && user.Password == password && user.IsAdmin == isAdmin && user.FirstName == firstName && user.LastName == lastName && user.PhoneNumber == phoneNumber && user.PostalCode == postalCode && user.City == city);
        }
    }
}
