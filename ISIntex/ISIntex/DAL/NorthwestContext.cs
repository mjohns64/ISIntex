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
        public DbSet<AssayTest> AssayTests { get; set; }
        public DbSet<Compound> Compounds { get; set; }
        public DbSet<RejectedEstimate> RejectedEstimates { get; set; }
        public DbSet<TestMaterials> TestMaterialss { get; set; }
        public DbSet<TestResults> TestResultss { get; set; }
        public DbSet<UserCredentials> UserCredentialss { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderTests> WorkOrderTestss { get; set; }
        public DbSet<Element> Elements { get; set; }

        public System.Data.Entity.DbSet<ISIntex.ViewModels.MyOrders> MyOrders { get; set; }
    }
}