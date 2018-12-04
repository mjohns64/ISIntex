using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    public class Compound
    {
        public int LTNumber { get; set; }
        public int CompoundSequenceCode { get; set; }
        public decimal Weight { get; set; }
        public decimal MolecularMass { get; set; }
        public string CompoundName { get; set; }
        public int Quantity { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime DateDue { get; set; }
        public string Appearance { get; set; }
        public int MTD { get; set; }
    }
}