using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SecurityDemo.Models;
namespace SecurityDemo.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User usermodel)
        {
            using (MVC_DBEntities entities = new MVC_DBEntities())
            {
                bool IsValidUser = entities.Users.Any(
                    user => user.UserName.ToLower() == usermodel.UserName
                    && user.UserPassword == usermodel.UserPassword);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(usermodel.UserName, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
        }
    }
}