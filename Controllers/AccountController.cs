using PaceWisdomAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PaceWisdomAssignment.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User _usr)
        {
            if (ModelState.IsValid)
            {
                if (_usr.Username == "admin" && _usr.Password == "ras@123")
                {
                    FormsAuthentication.SetAuthCookie(_usr.Username, false);
                    Session["Username"] = _usr.Username;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please enter all field carefully");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}