using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    public class CompoundTestResults
    {
        public Compound Compounds { get; set; }
        public IEnumerable<TestResults> TestResultss { get; set; }
    }
}