using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    public class RejectedWorkOrder
    {
        public int EstimateID { get; set; }
        public int CustomerID { get; set; }
        public string Comments { get; set; }
        public int LTNumber { get; set; }
        public decimal EstimatedPrice { get; set; }
        public int AssayID { get; set; }
    }
}