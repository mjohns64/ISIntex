using ISIntex.DAL;
using ISIntex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISIntex.Controllers
{
    public class CustomerController : Controller
    {

        private static NorthwestContext db = new NorthwestContext();
        public static List<Customer> CustomerInfo = db.Customers.ToList();

        // GET: Customer
        public ActionResult Index()
        {
            if (Authorized.userAuth == "customer")
            {
                foreach (var item in CustomerInfo)
                {
                    if (item.Email == Authorized.Email)
                    {
                        Authorized.CustomerID = item.CustomerID;
                        Authorized.FirstName = item.FirstName;
                        Authorized.LastName = item.LastName;
                        Authorized.Company = item.Company;
                        Authorized.Email = item.Email;
                        Authorized.Phone = item.Phone;
                        Authorized.Address = item.Address;
                        Authorized.City = item.City;
                        Authorized.State = item.State;
                        Authorized.Zip = item.Zip;
                    }
                } 
                return View(); 
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }
    }
}