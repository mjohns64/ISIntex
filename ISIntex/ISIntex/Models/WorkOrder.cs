using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{

    [Table("WorkOrder")]
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