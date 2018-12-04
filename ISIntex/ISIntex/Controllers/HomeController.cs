using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIntex.Models;

namespace ISIntex.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Catalog
        public ActionResult Catalog()
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
            if (Authorized.loginStatus == true)
            {
                if (Authorized.userAuth == "customer")
                {
                    return RedirectToAction("Index", "Customer");
                }
                else if (Authorized.userAuth == "sales")
                {
                    return RedirectToAction("Index", "Sales");
                }
                else if (Authorized.userAuth == "manager")
                {
                    return RedirectToAction("Index", "Manager");
                }
                else if (Authorized.userAuth == "technician")
                {
                    return RedirectToAction("Index", "Technician");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.error = null;
                return View();
            }
        }

        // GET: Log In
        public ActionResult NotAuthorized()
        {
            return View();
        }

        // GET: Log In
        public ActionResult LogOut()
        {
            Authorized.userAuth = null;
            Authorized.loginStatus = false;
            return View();
        }

        //POST: Login
        [HttpPost]
        public ActionResult LoginRouter(string username, string password)
        {
            if (username == "customer")
            {
                Authorized.userAuth = "customer";
                Authorized.loginStatus = true;
                return RedirectToAction("Index" , "Customer");
            }
            else if (username == "sales")
            {
                Authorized.userAuth = "sales";
                Authorized.loginStatus = true;
                return RedirectToAction("Index" , "Sales");
            }
            else if (username == "manager")
            {
                Authorized.userAuth = "manager";
                Authorized.loginStatus = true;
                return RedirectToAction("Index" , "Manager");
            }
            else if (username == "technician")
            {
                Authorized.userAuth = "technician";
                Authorized.loginStatus = true;
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