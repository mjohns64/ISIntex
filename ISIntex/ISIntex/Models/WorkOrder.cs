using System;
using System.Collections.Generic;
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
        public int? LTNumber { get; set; }
        public int? CustomerID { get; set; }
        public string Comments { get; set; }
        public decimal? EstimatedPrice { get; set; }
        public decimal? ActualPrice { get; set; }
        public string Status { get; set; }
        public int? AssayID { get; set; }
        public int? Element1 { get; set; }
        public int? Element2 { get; set; }
        public int? Element2Qty { get; set; }
        public int? Element1Qty { get; set; }
        public decimal? Weight { get; set; }
        public decimal? MolecularMass { get; set; }
        public string CompoundName { get; set; }
        public int Quantity { get; set; }
        public int? ReceivedBy { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime DateDue { get; set; }
        public string appearance { get; set; }
        public int? MTD { get; set; }
        public byte[] TestResultFile { get; set; }
        public bool? OptionalTests { get; set; }
      

    }
}