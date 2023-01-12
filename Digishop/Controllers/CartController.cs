﻿using Digishop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebshopDAL;
using WebshopLogic;

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace Digishop.Controllers
{
    public class CartController : Controller
    {
        OrderContainer orderContainer = new OrderContainer(new OrderDAL());
        ProductContainer productContainer = new ProductContainer(new ProductDAL());
        CartViewModel cvm = new CartViewModel();

        public IActionResult Index()
        {
            string CartID = "";

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("CartID")))
                CartID = HttpContext.Session.GetString("CartID");

            cvm.cartProducts = orderContainer.GetCartProducts(CartID);

            return View(cvm);
        }

        public IActionResult AddProductToCart(int productId)
        {
            //Add product to cart
            Product product =  productContainer.GetProductID(productId);

            if (String.IsNullOrEmpty(HttpContext.Session.GetString("CartID")))
            {
                HttpContext.Session.SetString("CartID", Guid.NewGuid().ToString());
            }

            orderContainer.AddToCart(HttpContext.Session.GetString("CartID"), productId, 1, product.ProductPrice);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult RemoveProductFromCart(int productId)
        {
            orderContainer.DeleteItemFromCart(HttpContext.Session.GetString("CartID"), productId);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult AddProductAmountToCart(int productId)
        {
            orderContainer.AddProductAmountToCart(HttpContext.Session.GetString("CartID"), productId);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Order()
        {

            if (String.IsNullOrEmpty(Convert.ToString(HttpContext.Session.GetInt32("UserID"))))
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                orderContainer.PlaceOrder((int)HttpContext.Session.GetInt32("UserID").Value);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
