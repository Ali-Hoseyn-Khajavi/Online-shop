using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.Categories
{
    public class CategoryEntityMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> _)
        {
            _.ToTable("Categories");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            _.Property(_ => _.Title).IsRequired().HasMaxLength(50);
            _.HasMany(_ => _.Goods)
                .WithOne(_ => _.category)
                .HasForeignKey(_ => _.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
