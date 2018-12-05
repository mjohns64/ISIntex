using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    [Table("RejectedEstimate")]
    public class RejectedEstimate
    {
        [Key]
        public int EstimateID { get; set; }
        public int CustomerID { get; set; }
        public string Comments { get; set; }
        public int LTNumber { get; set; }
        public decimal EstimatedPrice { get; set; }
        public int AssayID { get; set; }
        public int Element1 { get; set; }
        public int Element2 { get; set; }
        public int Element1Quantity { get; set; }
        public int Element2Quantity { get; set; }


    }
}