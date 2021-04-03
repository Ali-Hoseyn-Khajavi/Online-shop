using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Migrations.Migrations
{
    [Migration(202104031143)]
    public class _202104031143_Alter : Migration
    {
        public override void Down()
        {
            Delete.Column("Title");
        }

        public override void Up()
        {
            Alter.Table("GoodEntries").AddColumn("Title").AsString().NotNullable();
        }
    }
}
