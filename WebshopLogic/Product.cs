﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopLogic
{
    public class Product
    {     
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public DateTime Delete { get; set; }
        public int CategoryID { get; set; }

        public Product(ProductDTO productDTO)
        {
            this.ProductID = productDTO.ProductID;
            this.ProductName = productDTO.ProductName;
            this.ProductPrice = productDTO.ProductPrice;
            this.ProductDescription = productDTO.ProductDescription;
            this.ProductImage = productDTO.ProductImage;
            this.Delete = productDTO.Delete;
            this.CategoryID = productDTO.CategoryID;
        }
        public Product()
        {

        }

        //constructortest
        public Product(int productID, string productName, double productPrice, string productDescription, string productImage, DateTime delete, int categoryID)
        {
            ProductID = productID;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductDescription = productDescription;
            ProductImage = productImage;
            Delete = delete;
            CategoryID = categoryID;
        }
    }
}
