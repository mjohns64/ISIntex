using ISIntex.DAL;
using ISIntex.Models;
using ISIntex.ViewModels;
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
    public class ManagerController : Controller
    {

        private static NorthwestContext db = new NorthwestContext();
        public static List<Employee> EmployeeInfo = db.Employees.ToList();
        public static IEnumerable<SalesByRep> SalesByRepList = db.Database.SqlQuery<SalesByRep>("SELECT Employee.EmployeeID, Employee.FirstName, Employee.LastName, SUM(WorkOrder.ActualPrice) AS TotalRevenue FROM WorkOrder INNER JOIN Customer ON WorkOrder.CustomerID = Customer.CustomerID INNER JOIN Employee ON Customer.SalesRepID = Employee.EmployeeID WHERE WorkOrder.Status = 'Complete' AND UserTypeID = 2 GROUP BY Employee.EmployeeID, Employee.FirstName, Employee.LastName ORDER BY EmployeeID");
        public static IEnumerable<UnassignedCustomers> UnassignedCustomersList = db.Database.SqlQuery<UnassignedCustomers>("SELECT * FROM Customer WHERE SalesRepID is NULL");
        public static IEnumerable<TestAverages> TestAveragesList = db.Database.SqlQuery<TestAverages>("SELECT WorkOrder.AssayID, Assay.AssayType, SUM(WorkOrder.ActualPrice) AS TotalRevenue FROM Assay INNER JOIN WorkOrder ON Assay.AssayID = WorkOrder.AssayID GROUP BY WorkOrder.AssayID, Assay.AssayType ORDER BY WorkOrder.AssayID");

        // GET: Customer
        public ActionResult Index()
        {
            if (Authorized.userAuth == "manager")
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

        public ActionResult SalesByRep()
        {
            if (Authorized.userAuth == "manager")
            { 
                return View(SalesByRepList);
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }

        public ActionResult UnassignedCustomers()
        {
            if (Authorized.userAuth == "manager")
            {
                return View(UnassignedCustomersList);
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }

        public ActionResult TestAverages()
        {
            if (Authorized.userAuth == "manager")
            {
                return View(TestAveragesList);
            }
            else
            {
                return RedirectToAction("NotAuthorized", "Home");
            }
        }
    }
}