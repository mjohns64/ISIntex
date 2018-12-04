using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    public class TestResults
    {
        public int TestResultsID { get; set; }
        public string TestDocumentation { get; set; }
        public int LTNumber { get; set; }
        public int CompoundSequenceCode { get; set; }
    }
}