using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIntex.ViewModels
{
    public class SalesList
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int SalesRepID { get; set; }
        public string PaymentInfo { get; set; }
    
    }
}