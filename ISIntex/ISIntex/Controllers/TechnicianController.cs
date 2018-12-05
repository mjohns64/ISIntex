using ISIntex.DAL;
using ISIntex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISIntex.Controllers
{
    public class TechnicianController : Controller
    {

        private NorthwestContext db = new NorthwestContext();

        // GET: Customer
        public ActionResult Index()
        {
            //if (Authorized.userAuth == "technician")
            //{
            var stuffyStuff = db.Compounds.ToList();
            return View("WorkOrders", stuffyStuff);
            //}
            //else
            //{
                //return RedirectToAction("NotAuthorized", "Home");
            //}
        }

        public ActionResult TestResults(int LTNum, int CSC)
        {
            Compound compound = db.Compounds.Find(LTNum, CSC);
            //compound.TestResults = db.TestResults.Find(LTNum);
            return View();
        }
    }
}