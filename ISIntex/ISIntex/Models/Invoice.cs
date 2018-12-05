using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int WorkOrderID { get; set; }
        public DateTime DateSent { get; set; }
        public bool Paid { get; set; }
    }
}