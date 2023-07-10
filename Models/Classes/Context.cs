using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnlineCommercialAutomation.Models.Classes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Current> Currents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Expens> Expenses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<CargoTracking> CargoTrackings { get; set; }
        public DbSet<SalesTransaction> SalesTransactions { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}



