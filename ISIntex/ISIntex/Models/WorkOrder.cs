using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    public class WorkOrder
    {
        public int WorkOrderID { get; set; }
        public int CustomerID { get; set; }
        public string Comments { get; set; }
        public int LTNumber { get; set; }
        public decimal EstimatedPrice { get; set; }
        public decimal ActualPrice { get; set; }
        public string Status { get; set; }
        public int AssayID { get; set; }
    }
}