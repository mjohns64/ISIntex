using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    [Table("TestResults")]
    public class TestResults
    {
        [Key]
        public int TestResultID { get; set; }
        public byte[] TestDocumentation { get; set; }
        public int LTNumber { get; set; }
        public int CompoundSequenceCode { get; set; }
        public virtual Compound Compound { get; set; }
        

    }
}