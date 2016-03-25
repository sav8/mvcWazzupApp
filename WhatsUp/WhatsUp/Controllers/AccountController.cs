using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsUp.Models;
using System.Web.Security;

namespace WhatsUp.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private DbAccountRepository repository = new DbAccountRepository();

        public ActionResult Index()
        {
            //home view 
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (!repository.CreateAccount(model))
                {
                    ModelState.AddModelError("register-error", "The emailaddress or phonenumber already exists.");
                    return View();
                }
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Account account = repository.GetAccount(model.Emailaddress, model.Password);

                if (account != null)
                {
                    FormsAuthentication.SetAuthCookie(account.Emailaddress, false);

                    Session["loggedin_account"] = account;

                    return RedirectToAction("Index", "Contacts");
                }
            }
            else
            {
                ModelState.AddModelError("login-error", "The user name or password provided is incorrect");
            }
            return View(model);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
