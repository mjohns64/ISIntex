using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ISIntex.ViewModels
{
    public class SalesByRep
    {
        [DisplayName("Employee ID #")]
        public int EmployeeID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Total Revenue Brought In")]
        public decimal TotalRevenue { get; set; }
    }
}