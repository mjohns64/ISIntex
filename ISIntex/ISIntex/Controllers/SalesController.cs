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

        public static IEnumerable<SalesList> MySalesList = db.Database.SqlQuery<SalesList>("SELECT * FROM Customer WHERE SalesRepID = 3");
        

        // GET: Customer
        public ActionResult Index()
        {
            if (Authorized.userAuth == "sales")
            {
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