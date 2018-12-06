using ISIntex.DAL;
using ISIntex.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISIntex.Controllers
{
    public class TechnicianController : Controller
    {

        private static NorthwestContext db = new NorthwestContext();
        public static List<Employee> EmployeeInfo = db.Employees.ToList();

        // GET: Customer
        public ActionResult Index()
        {
            if (Authorized.userAuth == "technician")
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

        public ActionResult WorkOrders()
        {
            if (Authorized.userAuth == "technician")
            {
                var stuffyStuff = db.WorkOrders.OrderByDescending(c => c.DateReceived).Take(30).ToList();

                TempData["WOList"] = stuffyStuff;
                return View("WorkOrders", stuffyStuff);
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }

        public ActionResult Edit(int LTNum)
        {
            WorkOrder workOrder = db.WorkOrders.Find(LTNum);

            return View("EditTestResult", workOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LTNumber,OptionalTests, Weight, appearance, MTD, Status")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                WorkOrder dbWorkOrder = db.WorkOrders.Find(workOrder.LTNumber);

                dbWorkOrder.ReceivedBy = Authorized.EmployeeID;
                if (dbWorkOrder.OptionalTests != workOrder.OptionalTests)
                {
                    dbWorkOrder.OptionalTests = workOrder.OptionalTests;
                    if (dbWorkOrder.AssayID == 1)
                    {
                        if (dbWorkOrder.OptionalTests == true)
                        {
                            dbWorkOrder.EstimatedPrice = 1000;
                        }
                        else
                        {
                            dbWorkOrder.EstimatedPrice = 600;
                        }
                    }
                    else if (dbWorkOrder.AssayID == 2)
                    {
                        if (dbWorkOrder.OptionalTests == true)
                        {
                            dbWorkOrder.EstimatedPrice = 2100;
                        }
                        else
                        {
                            dbWorkOrder.EstimatedPrice = 1200;
                        }
                    }
                    else if (dbWorkOrder.AssayID == 3)
                    {
                        if (dbWorkOrder.OptionalTests == true)
                        {
                            dbWorkOrder.EstimatedPrice = 2400;
                        }
                        else
                        {
                            dbWorkOrder.EstimatedPrice = 3400;
                        }
                    }
                    else if (dbWorkOrder.AssayID == 4)
                    {
                        if (dbWorkOrder.OptionalTests == true)
                        {
                            dbWorkOrder.EstimatedPrice = 1000;
                        }
                        else
                        {
                            dbWorkOrder.EstimatedPrice = 4000;
                        }
                    }
                    else if (dbWorkOrder.AssayID == 5)
                    {
                        if (dbWorkOrder.OptionalTests == true)
                        {
                            dbWorkOrder.EstimatedPrice = 7200;
                        }
                        else
                        {
                            dbWorkOrder.EstimatedPrice = 9200;
                        }
                    }
                    else if (dbWorkOrder.AssayID == 6)
                    {
                        if (dbWorkOrder.OptionalTests == true)
                        {
                            dbWorkOrder.EstimatedPrice = 7500;
                        }
                        else
                        {
                            dbWorkOrder.EstimatedPrice = 10500;
                        }
                    }

                    dbWorkOrder.ActualPrice = dbWorkOrder.EstimatedPrice * (decimal).95;
                }
                


                dbWorkOrder.Weight = workOrder.Weight;
                dbWorkOrder.appearance = workOrder.appearance;
                dbWorkOrder.MTD = workOrder.MTD;
                dbWorkOrder.Status = workOrder.Status;

                db.Entry(dbWorkOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WorkOrders");
            }
            return View(workOrder);
        }

        public ActionResult TestResults(int LTNum, int CSC)
        {
            if (Authorized.userAuth == "technician")
            {
                var compoundTestResults = new CompoundTestResults();


                Compound compound = db.Compounds.Include("TestResults").FirstOrDefault(c => c.LTNumber == LTNum);

                foreach (var testResult in compound.TestResults.ToList())
                {
                    testResult.Compound = db.Compounds.Find(LTNum, CSC);
                }



                //var CompoundTestResultsQuery = db.Database.SqlQuery<string>("SELECT TR.TestResultID, TR.TestDocumentation, TR.LTNumber, TR.CompoundSequenceCode FROM Compound c INNER JOIN TestResults TR ON C.LTNumber = TR.LTNumber AND C.CompoundSequenceCode = TR.CompoundSequenceCode WHERE C.LTNumber = " + LTNum + " AND C.CompoundSequenceCode = " + CSC);

                //foreach (var item in CompoundTestResultsQuery)
                //{
                //compoundTestResults.TestResultss.TestResultID;
                //}

                //compoundTestResults.TestResultss = compoundTestResults.Compounds.Where(c => c.LTNumber == LTNum).FirstOrDefault().TestResults;
                return View(compound);
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }

        public ActionResult AddTestResult(int LTNum)
        {
            if (Authorized.userAuth == "technician")
            {              

                WorkOrder workOrder = db.WorkOrders.Find(LTNum);

                TempData["WorkOrder"] = workOrder;

                //return View(testResult);
                return View(workOrder);
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }

        [HttpPost]
        public ActionResult AddTestResult(HttpPostedFileBase fileUpload)
        {
            if (Authorized.userAuth == "technician")
            {
                WorkOrder workOrder = (WorkOrder)TempData["WorkOrder"];

                byte[] uploadedFile = new byte[fileUpload.InputStream.Length];
                fileUpload.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

                workOrder.TestResultFile = uploadedFile.ToArray();
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return View("ResultAdded", workOrder);
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }

        /*[HttpPost]
        public ActionResult AddTestResult(string testResult)
        {
            TestResults result = (TestResults)TempData["testResult"];

            TestResults newTestResult = db.TestResultss.Create();
            newTestResult.LTNumber = result.LTNumber;
            newTestResult.CompoundSequenceCode = result.CompoundSequenceCode;
            newTestResult.TestDocumentation = testResult;

            db.SaveChanges();
            return View("ResultAdded", newTestResult);
        }*/

        public ActionResult DownloadCSV()
        {
            if (Authorized.userAuth == "technician")
            {
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"LT Number\",\"Compound Sequence Code\",\"Weight\",\"Molecular Mass\",\"Compound Name\",\"Quantity\",\"Date Received\",\"Date Due\", \"Appearance\", \"Maximum Tolerable Dose\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=Work Orders.csv");
                Response.ContentType = "application/octet-stream";

                var compounds = db.Compounds.OrderByDescending(c => c.DateReceived).Take(30).ToList();

                foreach (var compound in compounds)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{6}\",\"{8}\",\"{9}\"",

                    compound.LTNumber,
                    compound.CompoundSequenceCode,
                    compound.Weight,
                    compound.MolecularMass,
                    compound.CompoundName,
                    compound.Quantity,
                    compound.DateReceived,
                    compound.DateDue,
                    compound.Appearance,
                    compound.MTD
                    ));
                }
                Response.Write(sw.ToString());
                Response.End();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }

        public ActionResult DownloadTestResult(int LTNum)
        {
                WorkOrder workOrder = db.WorkOrders.Find(LTNum);

                Response.AppendHeader("content-disposition", "attachment; filename=" + LTNum + "TestResults.txt"); //this will download the file
                return File(workOrder.TestResultFile, "plain/text");

        }
    }
}