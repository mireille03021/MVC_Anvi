namespace ANVI_Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViewWords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WordName = c.String(nullable: false, maxLength: 128),
                        WordContent = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ViewWords");
        }
    }
}
