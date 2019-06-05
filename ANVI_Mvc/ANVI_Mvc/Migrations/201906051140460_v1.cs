namespace ANVI_Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "OrderID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "OrderID");
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "OrderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "OrderID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Orders", "OrderID");
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "OrderID");
        }
    }
}
