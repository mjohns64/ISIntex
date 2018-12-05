﻿using ISIntex.DAL;
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
        private NorthwestContext db = new NorthwestContext();
       

        

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
                return View(db.RejectedEstimate.ToList());
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }
    }
}