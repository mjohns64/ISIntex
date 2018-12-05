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
        public static List<RejectedEstimate> rejectedEstimates = db.RejectedEstimates.ToList();


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

        public ActionResult OrderForm()
        {

            return View(); 

        }


        [HttpPost]
        public ActionResult OrderForm(RejectedEstimate rejectedEstimate)
        {
            db.Database.ExecuteSqlCommand("INSERT INTO RejectedEstimate (CustomerID, Comments, LTNumber, EstimatedPrice, AssayID, Element1, Element2, Element1Quantity, Element2Quantity) VALUES ('"
               + 0 + "','"
                + rejectedEstimate.Comments + "','"
                + 0 + "','"
                + 1000 + "','"
                + 0 + "','"
                 + rejectedEstimate.Element1 + "','"
                  + rejectedEstimate.Element2 + "','"
                   + rejectedEstimate.Element1Quantity + "','"
                    + rejectedEstimate.Element2Quantity + "');"
                    ); 



            return View("Confirmation", rejectedEstimate); 
            

        }

        public ActionResult MyOrderView()
        {

            return View(rejectedEstimates); 

        }



    }
}