using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OnlineShop.Persistence.EF
{
   public class EFDataContext:DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AccountingDocument> AccountingDocuments { get; set; }
        public DbSet<Good> goods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GoodEntry> GoodEntries { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesItem> SalesItems { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
