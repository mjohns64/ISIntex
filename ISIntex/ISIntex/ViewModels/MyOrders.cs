using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISIntex.ViewModels
{
    public class MyOrders
    {
        [Key]
        public int CustomerID { get; set; }
        public string Comments { get; set; }
        public decimal? ActualPrice { get; set; }
        public int? AssayID { get; set; }
        public decimal? Weight { get; set; }
        public decimal? MolecularMass { get; set; }
        public string CompoundName { get; set; }
        public int Quantity { get; set; } 
        public DateTime DateReceived { get; set; }
        public DateTime DateDue { get; set; }    
        public byte[] TestResultFile { get; set; }
        public int LTNumber { get; set;  }




    }
}