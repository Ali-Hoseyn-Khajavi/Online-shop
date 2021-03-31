using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Migrations.Migrations
{[Migration(202103311451)]
    public class _202103311451_CreatedTabels : Migration
    {
     
        public override void Up()
        {
            Create.Table("Categories")
                .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
                .WithColumn("Title").AsString().NotNullable();

            Create.Table("Goods")
                .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("Code").AsString()
                .WithColumn("MinimomStak").AsInt32()
                .WithColumn("CategoryId").AsInt32().NotNullable().ForeignKey("Fk_Goods_Categories", "Categories", "Id");

            Create.Table("Warehouses")
                .WithColumn("Id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("GoodId").AsInt32().NotNullable().ForeignKey("Fk_Warehouses_Goods", "Goods", "Id");

            Create.Table("GoodEntries")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("InvoiceNumber").AsString().NotNullable()
                .WithColumn("EntryDate").AsDateTime().NotNullable()
                .WithColumn("GoodId").AsInt32().NotNullable().ForeignKey("Fk_GoodEntries_Goods", "Goods", "Id");

            Create.Table("SalesInvoices")
               .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
               .WithColumn("CustomerName").AsString(50).NotNullable()
               .WithColumn("InvoiceNumber").AsString(20).NotNullable()
               .WithColumn("InvoiceDate").AsDateTime().NotNullable();

            Create.Table("SalesItems")
               .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
               .WithColumn("Count").AsInt32().NotNullable()
               .WithColumn("Price").AsDecimal().NotNullable()
               .WithColumn("InvoiceId").AsInt32().NotNullable()
                   .ForeignKey("FK_SalesItems_SalesInvoices", "SalesInvoices", "Id")
               .WithColumn("GoodId").AsInt32().NotNullable()
                   .ForeignKey("FK_SalesItems_Goods", "Goods", "Id");

            Create.Table("AccountingDocuments")
               .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
               .WithColumn("DocumentNumber").AsString(20).NotNullable()
               .WithColumn("InvoiceNumber").AsString(20).NotNullable()
               .WithColumn("Totalprice").AsDecimal().NotNullable()
               .WithColumn("DateOfDocument").AsDateTime().NotNullable()
               .WithColumn("InvoiceId").AsInt32().NotNullable()
                   .ForeignKey("FK_AccountingDocuments_SalesInvoices", "SalesInvoices", "Id");



        }
        public override void Down()
        {
            Delete.Table("AccountingDocuments");
            Delete.Table("SalesItems");
            Delete.Table("SalesInvoices");
            Delete.Table("GoodEntries");
            Delete.Table("Warehouses");
            Delete.Table("Goods");
            Delete.Table("Categories");
        }

    }
}
