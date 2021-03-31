using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.Goods
{
    public class GoodEntityMap : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> _)
        {
            _.ToTable("Goods");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            _.Property(_ => _.Title).IsRequired().HasMaxLength(50);
            _.Property(_ => _.Code).IsRequired();
            _.Property(_ => _.MinimomStak).IsRequired();
            _.Property(_ => _.CategoryId).IsRequired();
            _.HasMany(_ => _.Warehouses).WithOne(_ => _.good).HasForeignKey(_ => _.GoodId);
        }
    }
}
