using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;
using WebshopLogic;

namespace WebshopTest
{
    [TestClass]
    public class UserContainerTest
    {
        [TestMethod]
        public void CreateUser()
        {
            //arrange
            UserContainerTestStub userContainerTestStub = new UserContainerTestStub();
            UserContainer userContainer = new UserContainer(userContainerTestStub);
            User user3 = new User()
            {
                UserID = 3,
                Email = "S@hotmail.com",
                Password = "9012",
                IsAdmin = false,
                FirstName = "Sas",
                LastName = "allen",
                PhoneNumber = 0697532764,
                Address = "Heikantstraat",
                HouseNumber = "11",
                PostalCode = "2022AB",
                City = "Rotterdam",
            };
            //act
            userContainer.CreateUser(user3);
            //assert
            Assert.AreEqual(user3.UserID, userContainerTestStub.users.Last().UserID);
            Assert.AreEqual(user3.Email, userContainerTestStub.users.Last().Email);
            Assert.AreEqual(user3.Password, userContainerTestStub.users.Last().Password);
            Assert.AreEqual(user3.IsAdmin, userContainerTestStub.users.Last().IsAdmin);
            Assert.AreEqual(user3.FirstName, userContainerTestStub.users.Last().FirstName);
            Assert.AreEqual(user3.LastName, userContainerTestStub.users.Last().LastName);
            Assert.AreEqual(user3.PhoneNumber, userContainerTestStub.users.Last().PhoneNumber);
            Assert.AreEqual(user3.Address, userContainerTestStub.users.Last().Address);
            Assert.AreEqual(user3.HouseNumber, userContainerTestStub.users.Last().HouseNumber);
            Assert.AreEqual(user3.PostalCode, userContainerTestStub.users.Last().PostalCode);
            Assert.AreEqual(user3.City, userContainerTestStub.users.Last().City);
        }
        // laten controleren
        [TestMethod]
        public void UserExist()
        {
            //arrange
            UserContainerTestStub userContainerTestStub = new UserContainerTestStub();
            UserContainer userContainer = new UserContainer(userContainerTestStub);
            User user3 = new User()
            {
                UserID = 2,
                Email = "Sam@mail.com",
                Password = "5678",
                IsAdmin = false,
                FirstName = "Mas",
                LastName = "Gad",
                PhoneNumber = 0691268246,
                Address = "schipkaarten",
                HouseNumber = "1",
                PostalCode = "1221AD",
                City = "Tilburg",
            };
            //act
            var actual = (userContainer.UserExist(user3));
            //assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void UserExistNotTest()
        {
            //arrange
            UserContainerTestStub userContainerTestStub = new UserContainerTestStub();
            UserContainer userContainer = new UserContainer(userContainerTestStub);
            User user3 = new User()
            {
                UserID = 3,
                Email = "S@hotmail.com",
                Password = "9012",
                IsAdmin = false,
                FirstName = "Sas",
                LastName = "allen",
                PhoneNumber = 0697532764,
                Address = "Heikantstraat",
                HouseNumber = "11",
                PostalCode = "2022AB",
                City = "Rotterdam",
            };
            //act
            var actual = userContainer.UserExist(user3);
            //assert 
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void GetUserByEmailAndPasswordTest()
        {
            //arrange
            UserContainerTestStub userContainerTestStub = new UserContainerTestStub();
            UserContainer userContainer = new UserContainer(userContainerTestStub);
            User user1 = new User()
            {
                UserID = 1,
                Email = "Sam@hotmail.com",
                Password = "1234",
                IsAdmin = false,
                FirstName = "Sam",
                LastName = "Dag",
                PhoneNumber = 0644335690,
                Address = "steenmanslaan",
                HouseNumber = "10A",
                PostalCode = "4030AB",
                City = "Eindhoven",
            };
            //act
            var result = userContainer.GetUserByEmailAndPassword(user1);
            //assert
            Assert.AreEqual(result.Email, userContainerTestStub.users[0].Email);
            Assert.AreEqual(result.Password, userContainerTestStub.users[0].Password);
        }

        [TestMethod]
        public void UserExistsByEmailAndPasswordTest()
        {
            //arrange
            UserContainerTestStub userContainerTestStub = new UserContainerTestStub();
            UserContainer userContainer = new UserContainer(userContainerTestStub);
            User user1 = new User()
            {
                UserID = 1,
                Email = "Sam@hotmail.com",
                Password = "1234",
                IsAdmin = false,
                FirstName = "Sam",
                LastName = "Dag",
                PhoneNumber = 0644335690,
                Address = "steenmanslaan",
                HouseNumber = "10A",
                PostalCode = "4030AB",
                City = "Eindhoven",
            };

            //act
            var result = userContainer.UserExistsByEmailAndPassword(user1);
            //assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UserExistsNotByEmailAndPasswordTest()
        {
            //arrange
            UserContainerTestStub userContainerTestStub = new UserContainerTestStub();
            UserContainer userContainer = new UserContainer(userContainerTestStub);
            User user3 = new User()
            {
                UserID = 3,
                Email = "S@hotmail.com",
                Password = "9012",
                IsAdmin = false,
                FirstName = "Sas",
                LastName = "allen",
                PhoneNumber = 0697532764,
                Address = "Heikantstraat",
                HouseNumber = "11",
                PostalCode = "2022AB",
                City = "Rotterdam",
            };
            //act
            var result = userContainer.UserExistsByEmailAndPassword(user3);
            //assert
            Assert.IsFalse(result);
        }
    }
}
