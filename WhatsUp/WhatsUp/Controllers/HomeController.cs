using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatsUp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //home view
            ViewBag.Message = "Home page";
            return View();
        }
    }
}
