namespace ANVI_Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "ShipDate", c => c.DateTime());
            AlterColumn("dbo.OrderDetails", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.OrderDetails", "Quantity", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "Quantity", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.OrderDetails", "Price", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.Orders", "ShipDate", c => c.DateTime(nullable: false));
        }
    }
}
