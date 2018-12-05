using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    [Table("TestResults")]
    public class TestResults
    {
        public int TestResultID { get; set; }
        public string TestDocumentation { get; set; }
        public int LTNumber { get; set; }
        public int CompoundSequenceCode { get; set; }
    }
}