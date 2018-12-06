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

        public  List<Customer> CustomerInfo = db.Customers.ToList();
        public  List<WorkOrder> workOrder = db.WorkOrders.ToList();        
    



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
        public ActionResult OrderForm(WorkOrder workOrder)
        {

            //customerID we grab from the global model
            workOrder.CustomerID = Authorized.CustomerID;

            //comments are from user

            //assayID might already be in number form so we might be good.

            //Molecular mass formula: (Element 1 atomic weight * element 1 qty) + (Element 2 atomic weight * e2Qty
            //Element (need to create a model for this!) element 1 = db.Element.Find(Element1), element 2 = db.Element.Find(element2)
            Element element1 = db.Elements.Find(workOrder.Element1);
            Element element2 = db.Elements.Find(workOrder.Element2);

            workOrder.MolecularMass = (element1.AtomicMass * (decimal)workOrder.Element1Qty) + (element2.AtomicMass * (decimal)workOrder.Element2Qty);

            //Weight is rando generated? or equal to molar mass?
            workOrder.Weight = workOrder.MolecularMass;

            //CompoundName
            //element1.name + element1qty + element2.name + element2qty
            workOrder.CompoundName = element1.Symbol + workOrder.Element1Qty + element2.Symbol + workOrder.Element2Qty;

            //Qty in millileters from customer, set a display name showing that

            //received by will be null. If we have time we will set it to the first technician ID who clicks edit


            if (workOrder.AssayID == 1)
{
                if (workOrder.OptionalTests == true)
                {
                    workOrder.EstimatedPrice = 1000;
                }
                else
                {
                    workOrder.EstimatedPrice = 600;
                }
            }
            else if (workOrder.AssayID == 2)
            {
                if (workOrder.OptionalTests == true)
                {
                    workOrder.EstimatedPrice = 2100;
                }
                else
                {
                    workOrder.EstimatedPrice = 1200;
                }
            }
            else if (workOrder.AssayID == 3)
            {
                if (workOrder.OptionalTests == true)
                {
                    workOrder.EstimatedPrice = 2400;
                }
                else
                {
                    workOrder.EstimatedPrice = 3400;
                }
            }
            else if (workOrder.AssayID == 4)
            {
                if (workOrder.OptionalTests == true)
                {
                    workOrder.EstimatedPrice = 1000;
                }
                else
                {
                    workOrder.EstimatedPrice = 4000;
                }
            }
            else if (workOrder.AssayID == 5)
            {
                if (workOrder.OptionalTests == true)
                {
                    workOrder.EstimatedPrice = 7200;
                }
                else
                {
                    workOrder.EstimatedPrice = 9200;
                }
            }
            else if (workOrder.AssayID == 6)
            {
                if (workOrder.OptionalTests == true)
                {
                    workOrder.EstimatedPrice = 7500;
                }
                else
                {
                    workOrder.EstimatedPrice = 10500;
                }
            }

            TempData["OrderForm"] = workOrder;

            return View("Estimate", workOrder); 
            

        }

        
        public ActionResult Accept()
        {
            WorkOrder workOrder = (WorkOrder)TempData["OrderForm"];

            //ltnum calced by db

           

            //DateReceived. Calculate this to be today's data.
            workOrder.DateReceived = DateTime.Today;
            //Date Due. Take today's date and add 1 week to it.
            workOrder.DateDue = DateTime.Today.AddDays(7);


            //status is set to "Received"
            workOrder.Status = "Received";

            //Set actual price == to est price
            workOrder.ActualPrice = workOrder.EstimatedPrice * (decimal).95;

            //Appeareance is null for now. Technician can enter.

            //MTD is null. technician entered.

            //Element 1 is user entered

            //Element 2 is user entered

            //Qtys are user entered

            //Testresultfile is null for now. Technician uploaded.

            //optionalTests are user set.

            //add to database
            db.WorkOrders.Add(workOrder);

            db.SaveChanges();

            //save changes
            return View("Confirmation", workOrder);
        }


        public ActionResult Reject()
        {
            WorkOrder workOrder = (WorkOrder)TempData["OrderForm"];
            RejectedEstimate rejectedEstimate = new RejectedEstimate();

            rejectedEstimate.EstimatedPrice = (decimal)workOrder.EstimatedPrice;

            rejectedEstimate.Comments = workOrder.Comments;
            rejectedEstimate.AssayID = (int)workOrder.AssayID;
            rejectedEstimate.CustomerID = (int)workOrder.CustomerID;
            rejectedEstimate.Element1 = (int)workOrder.Element1;
            rejectedEstimate.Element2 = (int)workOrder.Element2;
            rejectedEstimate.Element1Quantity = (int)workOrder.Element2Qty;
            rejectedEstimate.Element1Quantity = (int)workOrder.Element1Qty;
            rejectedEstimate.CompoundName = workOrder.CompoundName;
            rejectedEstimate.OptionalTests = (bool)workOrder.OptionalTests;

            db.RejectedEstimates.Add(rejectedEstimate);
            db.SaveChanges();

            return View("Reject", rejectedEstimate);

        }

        public ActionResult MyOrderView()
        {

            return View(workOrder); 

        }



    }
}