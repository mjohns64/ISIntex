using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISIntex.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        // GET: Contact Us
        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        // GET: Log In
        public ActionResult Login()
        {
            ViewBag.error = null;
            return View();
        }

        //POST: Login
        [HttpPost]
        public ActionResult LoginRouter(string username, string password)
        {
            if (username == "customer")
            {
                return RedirectToAction("Index" , "Customer");
            }
            else if (username == "sales")
            {
                return RedirectToAction("Index" , "Sales");
            }
            else if (username == "manager")
            {
                return RedirectToAction("Index" , "Manager");
            }
            else if (username == "technician")
            {
               return RedirectToAction("Index" , "Technician");
            }
            else
            {
                ViewBag.error = "Incorrect Username or Password";
                return View("Login");
            }
        }
    }
}