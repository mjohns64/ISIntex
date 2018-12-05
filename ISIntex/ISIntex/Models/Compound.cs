using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    [Table("Table")]
    public class Compound
    {
        [DisplayName("LT Number")]
        [Key, Column(Order = 1)]
        public int LTNumber { get; set; }

        [DisplayName("Compound Sequence Code")]
        [Key, Column(Order =2)]
        public int CompoundSequenceCode { get; set; }

        [DisplayName("Weight (in milligrams)")]
        public decimal Weight { get; set; }

        [DisplayName("Molecular Mass")]
        public decimal MolecularMass { get; set; }

        [DisplayName("Compound Name")]
        public string CompoundName { get; set; }

        public int Quantity { get; set; }

        [DisplayName("Received By")]
        public string ReceivedBy { get; set; }

        [DisplayName("Date Received")]
        public DateTime DateReceived { get; set; }

        [DisplayName("Date Due")]
        public DateTime DateDue { get; set; }
        public string Appearance { get; set; }

        [DisplayName("Maximum Tolerated Dose")]
        public int MTD { get; set; }
    }
}