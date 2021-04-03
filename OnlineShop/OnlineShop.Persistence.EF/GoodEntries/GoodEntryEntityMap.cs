using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.GoodEntries
{
    public class GoodEntryEntityMap : IEntityTypeConfiguration<GoodEntry>
    {
        public void Configure(EntityTypeBuilder<GoodEntry> _)
        {
            _.ToTable("GoodEntries");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            _.Property(_ => _.Count).IsRequired();
            _.Property(_ => _.InvoiceNumber).IsRequired();
            _.Property(_ => _.GoodId).IsRequired();
            _.HasOne(_ => _.good).WithMany(_ => _.GoodEntries)
                 .HasForeignKey(_ => _.GoodId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
