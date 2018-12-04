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
    }
}