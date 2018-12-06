using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ISIntex.ViewModels
{
    public class RejectedEstimates
    {
        [DisplayName("Estimate ID #")]
        public int EstimateID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }

        [DisplayName("Estimated Price")]
        public decimal EstimatedPrice { get; set; }

        [DisplayName("Assay ID #")]
        public int AssayID { get; set; }

        [DisplayName("Compound Name")]
        public string CompoundName { get; set; }

        [DisplayName("Optional Tests")]
        public bool? OptionalTests { get; set; }
    }
}