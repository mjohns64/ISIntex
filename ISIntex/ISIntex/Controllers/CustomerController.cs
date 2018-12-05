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

        private NorthwestContext db = new NorthwestContext(); 

        // GET: Customer
        public ActionResult Index()
        {
            if (Authorized.userAuth == "customer")
            {
                 
                return View(); 
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }
    }
}