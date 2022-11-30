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
            Product product2 = new Product()
            {
                ProductID = 2,
                ProductName = "Product Two",
                ProductPrice = 39.99,
                ProductDescription = "Product Two is the newest one",
                ProductImage = "TestProduct.PNG",
                CategoryID = 2,
            };
            //act
            var actual = (productContainer.ExistProduct(product2.ProductName));
            //assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void TestNotExistedProduct()
        {
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
            var actual = (productContainer.ExistProduct(product3.ProductName));
            //assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void GetAllProducts()
        {
            //arrange
            ProductContainerTestStub productContainerTestStub = new ProductContainerTestStub();
            ProductContainer productContainer = new ProductContainer(productContainerTestStub);
            //act
            List<Product> products = productContainer.GetAllProducts();
            //assert
            Assert.AreEqual(productContainerTestStub.GetAllProducts().Count, products.Count);
            for (int i = 0; i < products.Count; i++)
            {
                Assert.AreEqual(products[i].ProductID, productContainerTestStub.products[i].ProductID);
                Assert.AreEqual(products[i].ProductName, productContainerTestStub.products[i].ProductName);
                Assert.AreEqual(products[i].ProductPrice, productContainerTestStub.products[i].ProductPrice);
                Assert.AreEqual(products[i].ProductDescription, productContainerTestStub.products[i].ProductDescription);
                Assert.AreEqual(products[i].ProductImage, productContainerTestStub.products[i].ProductImage);
                Assert.AreEqual(products[i].CategoryID, productContainerTestStub.products[i].CategoryID);
            }
        }
        [TestMethod]
        public void GetAllProductsByCategoryID()
        {
            //arrange
            ProductContainerTestStub productContainerTestStub = new ProductContainerTestStub();
            ProductContainer productContainer = new ProductContainer(productContainerTestStub);
            //act
            //assert
        }
        [TestMethod]
        public void GetProductIDTest()
        {
            //arrange
            ProductContainerTestStub productContainerTestStub = new ProductContainerTestStub();
            ProductContainer productContainer = new ProductContainer(productContainerTestStub);
            //act
            var ExpectedID = productContainer.GetProductID(1);
            //assert
            Assert.AreEqual(1, productContainerTestStub.products[0].ProductID);
        }
        [TestMethod]
        public void GetTop8productTest()
        {
            //arrange
            ProductContainerTestStub productContainerTestStub = new ProductContainerTestStub();
            ProductContainer productContainer = new ProductContainer(productContainerTestStub);
            //act
            List<Product> products = productContainer.GetTop8product();
            //assert
            Assert.AreEqual(products.Count, productContainerTestStub.products.Count);
            //Assert.AreEqual(products.Select(x => x.ProductID = productContainerTestStub.products);

        }
    }
}
