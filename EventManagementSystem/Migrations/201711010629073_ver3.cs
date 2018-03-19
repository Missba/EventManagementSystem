namespace EventManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.costs",
                c => new
                    {
                        CostID = c.Int(nullable: false, identity: true),
                        Items = c.String(),
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CostID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.costs");
        }
    }
}
