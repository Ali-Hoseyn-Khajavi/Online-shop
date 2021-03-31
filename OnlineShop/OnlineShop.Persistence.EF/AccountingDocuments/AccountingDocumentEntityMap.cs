using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.AccountingDocuments
{
    public class AccountingDocumentEntityMap : IEntityTypeConfiguration<AccountingDocument>
    {
        public void Configure(EntityTypeBuilder<AccountingDocument> _)
        {
            _.ToTable("AccountingDocuments");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            _.Property(_ => _.DocumentNumber).IsRequired();
            _.Property(_ => _.InvoiceNumber).IsRequired();
            _.Property(_ => _.Totalprice).IsRequired();
            _.Property(_ => _.DateOfDocument).IsRequired();
            _.Property(_ => _.InvoiceId).IsRequired();
            _.HasOne(_ => _.salesInvoice).WithMany(_ => _.accountingDocuments)
                .HasForeignKey(_ => _.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
