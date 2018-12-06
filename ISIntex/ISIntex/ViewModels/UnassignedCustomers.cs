using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ISIntex.ViewModels
{
    public class UnassignedCustomers
    {
        [DisplayName("Customer ID #")]
        public int CustomerID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        [DisplayName("Sales Rep ID #")]
        public int? SalesRepID { get; set; }

        [DisplayName("Payment Information")]
        public string PaymentInfo { get; set; }
    }
}