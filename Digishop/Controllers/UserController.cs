﻿using Digishop.Models;
using Microsoft.AspNetCore.Mvc;
using WebshopDAL;
using WebshopLogic;

namespace Digishop.Controllers
{
    public class UserController : Controller
    {
        User user = new User();
        UserContainer userContainer = new UserContainer(new UserDAL());

        [HttpPost]
        public IActionResult CreateUser(UserViewModel uvm)
        {
            user.FirstName = uvm.FirstName;
            user.LastName = uvm.LastName;
            user.Email = uvm.Email;
            user.Password = uvm.Password;
            user.IsAdmin = uvm.IsAdmin;
            if (!ModelState.IsValid)
                if (!userContainer.UserExist(user))
                {
                    userContainer.CreateUser(user);
                    return View();
                }
                else
                {
                    ViewBag.Message = "Deze gebruiker heeft al een account";
                }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            UserViewModel user = new UserViewModel();
            return View(user);
        }
        [HttpPost]
        public IActionResult Login(UserViewModel uvm)
        {
            user.Email = uvm.Email;
            user.Password = uvm.Password;
            if (userContainer.UserExistsByEmailAndPassword(user))
            {
                User loggedplayer = userContainer.GetUserByEmailAndPassword(user);
                if (loggedplayer.IsAdmin == true)
                {
                    HttpContext.Session.SetInt32("IsAdmin", 1);
                    HttpContext.Session.SetInt32("UserID", loggedplayer.UserID);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    loggedplayer.IsAdmin = false;
                    HttpContext.Session.SetInt32("UserID", loggedplayer.UserID);
                    return RedirectToAction("Index", "Home");   
                }
                
            }
            return View();
        }
        //public IActionResult Login(UserViewModel uvm) 
        //{
        //    user.Email = uvm.Email;
        //    user.Password = uvm.Password;
        //    if (userContainer.UserExistsByEmailAndPassword(user))
        //    {
        //        return null;
        //        // User loggedplayer = userContainer.Get
        //        return View();
        //    }
        //}
            

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAdmin");
            HttpContext.Session.Remove("Bwm6TXkr7P");
            return RedirectToAction("Index", "Home");
        }
    }
}
