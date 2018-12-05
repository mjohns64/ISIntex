using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    public static class Authorized
    {
        [Key]
        public static string userAuth = null;
        public static bool loginStatus = false;

        //Customer Logged in Info
        public static int CustomerID = 0;
        public static string FirstName = null;
        public static string LastName = null;
        public static string Company = null;
        public static string Email = null;
        public static string Phone = null;
        public static string Address = null;
        public static string City = null;
        public static string State = null;
        public static string Zip = null;
        public static int SalesRepID = 0;
        public static string PaymentInfo = null;

        //Employee ID 
        public static int EmployeeID = 0;

    }
}