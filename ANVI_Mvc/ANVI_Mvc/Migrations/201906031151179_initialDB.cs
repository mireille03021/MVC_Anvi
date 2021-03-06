namespace ANVI_Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 30, fixedLength: true),
                        City = c.String(maxLength: 15, fixedLength: true),
                        Country = c.String(maxLength: 15, fixedLength: true),
                        Address = c.String(),
                        ZipCode = c.String(maxLength: 10, fixedLength: true),
                        BankAccount = c.String(maxLength: 20, fixedLength: true),
                        CreditCard = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                        ShippingID = c.Int(),
                        RecipientName = c.String(nullable: false, maxLength: 15),
                        RecipientAddressee = c.String(nullable: false, maxLength: 30),
                        RecipientZipCod = c.String(maxLength: 10),
                        RecipientCity = c.String(nullable: false, maxLength: 10),
                        RecipientPhone = c.String(nullable: false, maxLength: 20),
                        Payment = c.String(nullable: false, maxLength: 15),
                        OrderDate = c.DateTime(nullable: false),
                        Remaeks = c.String(maxLength: 50),
                        ShipDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Shippers", t => t.ShippingID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ShippingID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        PDID = c.String(nullable: false, maxLength: 10),
                        OrderID = c.Int(nullable: false),
                        Price = c.Decimal(storeType: "money"),
                        Quantity = c.Decimal(storeType: "money"),
                        Discount = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => new { t.PDID, t.OrderID })
                .ForeignKey("dbo.ProductDetails", t => t.PDID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.PDID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        PDID = c.String(nullable: false, maxLength: 10),
                        ProductID = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        SizeID = c.Int(nullable: false),
                        ColorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PDID)
                .ForeignKey("dbo.Colors", t => t.ColorID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.Sizes", t => t.SizeID)
                .Index(t => t.ProductID)
                .Index(t => t.SizeID)
                .Index(t => t.ColorID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        ColorName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImgID = c.Int(nullable: false, identity: true),
                        PDID = c.String(nullable: false, maxLength: 10),
                        ImgName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ImgID)
                .ForeignKey("dbo.ProductDetails", t => t.PDID)
                .Index(t => t.PDID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        CategoryID = c.Int(),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.DesDetails",
                c => new
                    {
                        DDID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Detail = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DDID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.DesSubTitles",
                c => new
                    {
                        DSTID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        SubTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DSTID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        SizeID = c.Int(nullable: false, identity: true),
                        SizeTitle = c.String(nullable: false, maxLength: 10),
                        SizeContext = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.SizeID);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperID = c.Int(nullable: false, identity: true),
                        ShippName = c.String(nullable: false, maxLength: 15),
                        Phone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.ShipperID);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Orders", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ShippingID", "dbo.Shippers");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.ProductDetails", "SizeID", "dbo.Sizes");
            DropForeignKey("dbo.ProductDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.DesSubTitles", "ProductID", "dbo.Products");
            DropForeignKey("dbo.DesDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "PDID", "dbo.ProductDetails");
            DropForeignKey("dbo.Images", "PDID", "dbo.ProductDetails");
            DropForeignKey("dbo.ProductDetails", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.DesSubTitles", new[] { "ProductID" });
            DropIndex("dbo.DesDetails", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Images", new[] { "PDID" });
            DropIndex("dbo.ProductDetails", new[] { "ColorID" });
            DropIndex("dbo.ProductDetails", new[] { "SizeID" });
            DropIndex("dbo.ProductDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.OrderDetails", new[] { "PDID" });
            DropIndex("dbo.Orders", new[] { "ShippingID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Shippers");
            DropTable("dbo.Sizes");
            DropTable("dbo.DesSubTitles");
            DropTable("dbo.DesDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Images");
            DropTable("dbo.Colors");
            DropTable("dbo.ProductDetails");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}
