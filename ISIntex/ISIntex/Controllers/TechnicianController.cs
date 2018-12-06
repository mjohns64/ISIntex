using ISIntex.DAL;
using ISIntex.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            //.Where(c => c.DateReceived > DateTime.Parse("12/1/2018"))
            var stuffyStuff = db.Compounds.OrderByDescending(c => c.DateReceived).Take(30).ToList();

            TempData["WOList"] = stuffyStuff;
            return View("WorkOrders", stuffyStuff);
            //}
            //else
            //{
                //return RedirectToAction("NotAuthorized", "Home");
            //}
        }

        public ActionResult TestResults(int LTNum, int CSC)
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

        public ActionResult AddTestResult(int LTNum, int CSC)
        {
            TestResults testResult = new TestResults();
            testResult.LTNumber = LTNum;
            testResult.CompoundSequenceCode = CSC;

            TempData["testResult"] = testResult;

            //return View(testResult);
            return View();
        }

        [HttpPost]
        public ActionResult AddTestResult(HttpPostedFileBase fileUpload)
        {
            TestResults result = (TestResults)TempData["testResult"];

            byte[] uploadedFile = new byte[fileUpload.InputStream.Length];
            fileUpload.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            TestResults newTestResult = db.TestResultss.Create();
            newTestResult.LTNumber = result.LTNumber;
            newTestResult.CompoundSequenceCode = result.CompoundSequenceCode;
            newTestResult.TestDocumentation = uploadedFile.ToArray();

            db.TestResultss.Add(newTestResult);
            db.SaveChanges();
            return View("ResultAdded", newTestResult);
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
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"LT Number\",\"Compound Sequence Code\",\"Weight\",\"Molecular Mass\",\"Compound Name\",\"Quantity\",\"Date Received\",\"Date Due\", \"Appearance\", \"Maximum Tolerable Dose\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=registereduser.csv");
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

        public ActionResult DownloadTestResult()
        {
            TestResults testResult = new TestResults();

            testResult = db.TestResultss.FirstOrDefault();

            Response.AppendHeader("content-disposition", "attachment; filename=file.txt"); //this will open in a new tab.. remove if you want to open in the same tab.
            return File(testResult.TestDocumentation, "plain/text");
        }
    }
}