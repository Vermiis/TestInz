using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zarzadzanieTematami.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        /*
        public ActionResult Index2()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Index", "AdminController", new { area = "Admin" });
            else if (User.IsInRole("Student"))
                return RedirectToAction("Index", "UserController", new { area = "Student" });
            else if (User.IsInRole("Promotor"))
                return RedirectToAction("Index", "UserController", new { area = "Promotor" });
                }*/


        

    }
}