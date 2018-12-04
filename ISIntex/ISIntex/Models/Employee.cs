using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeFName { get; set; }
        public string EmployeeLName { get; set; }
        public string EmployeeEmail { get; set; }
        public int UserTypeID { get; set; }
    }
}