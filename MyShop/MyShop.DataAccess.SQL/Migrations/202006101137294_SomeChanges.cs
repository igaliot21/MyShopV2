namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Lastname", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Lastname", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Zipcode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Zipcode", c => c.String());
            AlterColumn("dbo.Orders", "State", c => c.String());
            AlterColumn("dbo.Orders", "City", c => c.String());
            AlterColumn("dbo.Orders", "Street", c => c.String());
            AlterColumn("dbo.Orders", "Email", c => c.String());
            AlterColumn("dbo.Orders", "Lastname", c => c.String());
            AlterColumn("dbo.Orders", "FirstName", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Lastname", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
    }
}
