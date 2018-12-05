using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIntex.ViewModels
{
    public class SalesByRep
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}