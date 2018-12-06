using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ISIntex.ViewModels
{
    public class TestAverages
    {
        [DisplayName("Assay ID #")]
        public int AssayID { get; set; }

        [DisplayName("Assay Name")]
        public string AssayType { get; set; }

        [DisplayName("Total Revenue Brought In")]
        public decimal TotalRevenue { get; set; }
    }
}