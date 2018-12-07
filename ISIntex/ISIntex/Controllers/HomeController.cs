using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIntex.DAL;
using ISIntex.Models;

namespace ISIntex.Controllers
{

    public class HomeController : Controller
    {

        private static NorthwestContext db = new NorthwestContext();
        public static IEnumerable<UserCredentials> UserCredentials = db.Database.SqlQuery<UserCredentials>("Select * FROM UserCredientials;");

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
            ViewBag.passwordError = null;
            return View();
        }

        //Post: SignUp
        [HttpPost]
        public ActionResult SignUp(Customer customer , string password)
        {
            if (ModelState.IsValid && password != "")
            {
                db.Database.ExecuteSqlCommand("INSERT INTO UserCredientials (Username,Password,UserTypeID) VALUES ('"
                    + customer.Email + "','"
                    + password + "','"
                    + "1');"
                    );

                db.Database.ExecuteSqlCommand("INSERT INTO customer (FirstName,LastName,Company,Email,Phone,Address,City,State,Zip) VALUES ('" 
                    + customer.FirstName + "','"
                    + customer.LastName + "','"
                    + customer.Company + "','"
                    + customer.Email + "','"
                    + customer.Phone + "','"
                    + customer.Address + "','"
                    + customer.City + "','"
                    + customer.State + "','"
                    + customer.Zip + "');"
                    );

                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (password == "")
                {
                    ViewBag.passwordError = "This is required";
                }
                return View("SignUp");
            }
 
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

        // GET: Not Authorized
        public ActionResult NotAuthorized()
        {
            return View();
        }

        // GET: Log Out
        public ActionResult LogOut()
        {
            Authorized.CustomerID = 0;
            Authorized.FirstName = null;
            Authorized.LastName = null;
            Authorized.Company = null;
            Authorized.Email = null;
            Authorized.Phone = null;
            Authorized.Address = null;
            Authorized.City = null;
            Authorized.State = null;
            Authorized.Zip = null;
            Authorized.Email = null;
            Authorized.userAuth = null;
            Authorized.loginStatus = false;
            return View();
        }

        //POST: Login
        [HttpPost]
        public ActionResult LoginRouter(string username, string password)
        {
            //Verify the username and password is Valid and change to loggin = true and identify type
            foreach (var item in UserCredentials)
            {
                if (item.Username.ToLower() == username.ToLower() && item.Password == password)
                {
                    Authorized.Email = username;

                    if (item.UserTypeID == 1)
                    {
                        Authorized.userAuth = "customer";
                        Authorized.loginStatus = true;
                        return RedirectToAction("Index", "Customer");
                    }
                    else if (item.UserTypeID == 2)
                    {
                        Authorized.userAuth = "sales";
                        Authorized.loginStatus = true;
                        return RedirectToAction("Index", "Sales");
                    }
                    else if (item.UserTypeID == 3)
                    {
                        Authorized.userAuth = "manager";
                        Authorized.loginStatus = true;
                        return RedirectToAction("Index", "Manager");
                    }
                    else
                    {
                        Authorized.userAuth = "technician";
                        Authorized.loginStatus = true;
                        return RedirectToAction("Index", "Technician");
                    }
                }
            }

            ViewBag.error = "Incorrect Username or Password";
            return View("Login");
        }
    }
}