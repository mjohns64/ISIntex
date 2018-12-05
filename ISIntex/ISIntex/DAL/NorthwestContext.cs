using ISIntex.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ISIntex.DAL
{
    public class NorthwestContext : DbContext
    {
        public NorthwestContext() : base("NorthwestContext") {


        }

        public DbSet<Assay> Assays { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<RejectedEstimate> RejectedEstimate { get; set; }



    }
}