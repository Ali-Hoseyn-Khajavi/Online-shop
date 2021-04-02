using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;
namespace OnlineShop.Persistence.EF.SalesItems
{
    public class SalesItemEntityMap : IEntityTypeConfiguration<SalesItem>
    {
        public void Configure(EntityTypeBuilder<SalesItem> _)
        {
            _.ToTable("SalesItems");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            _.Property(_ => _.Count).IsRequired();
            _.Property(_ => _.Price).IsRequired();
            _.Property(_ => _.GoodId).IsRequired();
            _.Property(_ => _.InvoiceId).IsRequired();
            _.HasOne(_ => _.good).WithMany(_ => _.SalesItems).HasForeignKey(_ => _.GoodId);
            _.HasOne(_ => _.salesInvoice).WithMany(_ => _.SalesItems).HasForeignKey(_=>_.InvoiceId);
        }
    }
}
