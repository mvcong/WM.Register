using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WM.Register.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Email"))
            //    {
            //        HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["Email"];
            //        // retrieve cookie data here
            //    }
            //}
            if (User.Identity.IsAuthenticated)
            {
                return View(HttpContext.User);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        
            
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}