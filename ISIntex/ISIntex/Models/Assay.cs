using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{

    [Table("Assay")]
    public class Assay
    {
        public int AssayID { get; set; }
        public int AssayType { get; set; }
        public int EstTimeCompletion { get; set; }
        public string AssayDescription { get; set; }
        public string AssayAbreviation { get; set; }
    }
}