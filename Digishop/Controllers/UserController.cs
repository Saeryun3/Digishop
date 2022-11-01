using Digishop.Models;
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
    }
}
