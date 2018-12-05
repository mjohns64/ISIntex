using ISIntex.DAL;
using ISIntex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISIntex.Controllers
{
    public class SalesController : Controller
    {
        private static NorthwestContext db = new NorthwestContext();
        public static List<Employee> EmployeeInfo = db.Employees.ToList();



        // GET: Customer
        public ActionResult Index()
        {
            if (Authorized.userAuth == "sales")
            {
                foreach (var item in EmployeeInfo)
                {
                    if (item.EmployeeEmail == Authorized.Email)
                    {
                        Authorized.FirstName = item.FirstName;
                        Authorized.LastName = item.LastName;
                        Authorized.EmployeeID = item.EmployeeID;
                    }
                }

                return View();
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }

        public ActionResult RejectedEstimate()
        {
            if (Authorized.userAuth == "sales")
            {
                return View(db.RejectedEstimates.ToList());
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }
    }
}