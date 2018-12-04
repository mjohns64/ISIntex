using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    public class TestMaterials
    {
        public int MaterialID { get; set; }
        public int AssayID { get; set; }
        public string MaterialName { get; set; }
        public int MaterialQuantity { get; set; }
        public decimal MaterialCost { get; set; }
    }
}