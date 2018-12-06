using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Estimate ID #")]
        public int EstimateID { get; set; }

        [DisplayName("Customer ID #")]
        public int CustomerID { get; set; }

        public string Comments { get; set; }

        [DisplayName("Estimated Price")]
        public decimal EstimatedPrice { get; set; }

        [DisplayName("Assay ID #")]
        public int AssayID { get; set; }
        public int Element1 { get; set; }
        public int Element2 { get; set; }
        public int Element1Quantity { get; set; }
        public int Element2Quantity { get; set; }
        public string CompoundName { get; set; }
        public bool OptionalTests { get; set; }


    }
}