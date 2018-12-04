using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    public class AssayTest
    {
        public int TestID { get; set; }
        public int AssayID { get; set; }
        public string Testname { get; set; }
        public bool Required { get; set; }
        public decimal AssayCost { get; set; }
    }
}