using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    [Table("Element")]
    public class Element
    {
        [Key]
        public int AtomicNumber { get; set; }
        public decimal AtomicMass { get; set; }
        public string ChemicalName { get; set; }
        public string Symbol { get; set; }
    }
}