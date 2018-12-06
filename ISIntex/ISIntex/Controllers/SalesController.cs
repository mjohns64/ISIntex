using ISIntex.DAL;
using ISIntex.Models;
using ISIntex.ViewModels;
using System;
using System.Collections;
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
        public IEnumerable<SalesList> MySalesList = db.Database.SqlQuery<SalesList>("SELECT * FROM Customer WHERE SalesRepID = " + Authorized.EmployeeID);
        public IEnumerable<RejectedEstimates> RejectedEstimatesList = db.Database.SqlQuery<RejectedEstimates>("SELECT RejectedEstimate.EstimateID, Customer.FirstName, Customer.LastName, Customer.Company, Customer.Email, Customer.Phone, RejectedEstimate.Comments, RejectedEstimate.EstimatedPrice, RejectedEstimate.AssayID, RejectedEstimate.CompoundName, RejectedEstimate.OptionalTests FROM RejectedEstimate INNER JOIN Customer ON RejectedEstimate.CustomerID = Customer.CustomerID Order BY Customer.LastName");

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
                return View(RejectedEstimatesList);
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM RejectedEstimate WHERE EstimateID = " + id);
            return RedirectToAction("RejectedEstimate");
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult MyClients()
        {
            return View(MySalesList);
        }
    }
}