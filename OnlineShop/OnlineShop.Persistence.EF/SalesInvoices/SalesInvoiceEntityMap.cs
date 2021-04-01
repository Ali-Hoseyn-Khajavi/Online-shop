using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;
namespace OnlineShop.Persistence.EF.SalesInvoices
{
    public class SalesInvoiceEntityMap : IEntityTypeConfiguration<SalesInvoice>
    {
        public void Configure(EntityTypeBuilder<SalesInvoice> _)
        {
            _.ToTable("SalesInvoices");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.CustomerName).IsRequired();
            _.Property(_ => _.InvoiceNumber).IsRequired();
            _.Property(_ => _.InvoiceDate).IsRequired();
        }
    }
}
