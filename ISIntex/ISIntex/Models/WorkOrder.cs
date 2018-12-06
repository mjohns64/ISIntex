using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    [Table("WorkOrder")]
    public class WorkOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("LT Number")]
        public int? LTNumber { get; set; }
        public int? CustomerID { get; set; }
        public string Comments { get; set; }
        public decimal? EstimatedPrice { get; set; }
        public decimal? ActualPrice { get; set; }
        public string Status { get; set; }
        [DisplayName("Assay")]
        public int? AssayID { get; set; }
        [DisplayName("Element 1")]
        public int? Element1 { get; set; }
        [DisplayName("Element 2")]
        public int? Element2 { get; set; }
        [DisplayName("Element 1 Quantity")]
        public int? Element1Qty { get; set; }
        [DisplayName("Element 2 Quantity")]
        public int? Element2Qty { get; set; }

        [RegularExpression(@"^\d+.\d{0,20}$", ErrorMessage ="Must be a number")]
        public decimal? Weight { get; set; }
        [DisplayName("Molecular Mass")]
        public decimal? MolecularMass { get; set; }

        [DisplayName("Compound Name")]
        public string CompoundName { get; set; }
        [DisplayName("Quantity (in milliliters")]
        public int Quantity { get; set; }
        public int? ReceivedBy { get; set; }
        [DisplayName("Date Received")]
        public DateTime DateReceived { get; set; }
        [DisplayName("Date Due")]
        public DateTime DateDue { get; set; }
        [DisplayName("Compound Appearance")]
        public string appearance { get; set; }
        [DisplayName("Maximum Tolerated Dose (in milliliters")]
        public int? MTD { get; set; }
        [DisplayName("Test Result File")]
        public byte[] TestResultFile { get; set; }
        [DisplayName("Optional Tests (T/F)")]
        public bool? OptionalTests { get; set; }
      

    }
}