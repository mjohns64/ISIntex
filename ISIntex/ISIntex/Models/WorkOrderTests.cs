﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    [Table("WorkOrderTests")]
    public class WorkOrderTests
    {
        [Key]
        public int WorkOrderTestsID { get; set; }
        public int WorkOrderID { get; set; }
    }
}