﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopLogic;

namespace WebshopTest
{
    [TestClass]

    public class ProductContainerTest
    {
        [TestMethod]
        public void CreateProducttest()
        {
            //arrange
            ProductContainerTestStub productContainerTestStub = new ProductContainerTestStub();
            ProductContainer productContainer = new ProductContainer(productContainerTestStub);
            Product product3 = new Product()
            {
                ProductID = 3,
                ProductName = "Product Three",
                ProductPrice = 49.99,
                ProductDescription = "Product three is better the one and two",
                ProductImage = "TestPro.PNG",
                CategoryID = 1,
            };
            //act
            productContainer.CreateProduct(product3);
            //assert
            Assert.AreEqual(product3.CategoryID, productContainerTestStub.products.Last().CategoryID);
            Assert.AreEqual(product3.ProductName, productContainerTestStub.products.Last().ProductName);
            Assert.AreEqual(product3.ProductPrice, productContainerTestStub.products.Last().ProductPrice);
            Assert.AreEqual(product3.ProductID, productContainerTestStub.products.Last().ProductID);
            Assert.AreEqual(product3.ProductDescription, productContainerTestStub.products.Last().ProductDescription);
            Assert.AreEqual(product3.ProductImage, productContainerTestStub.products.Last().ProductImage);
        }
        [TestMethod]
        public void TestExistProduct()
        {
            //arrange
            ProductContainerTestStub productContainerTestStub = new ProductContainerTestStub();
            ProductContainer productContainer = new ProductContainer(productContainerTestStub);
            //act
            //assert
        }
        [TestMethod]
        public void TestNotExistedProduct()
        {

        }
    }
}
