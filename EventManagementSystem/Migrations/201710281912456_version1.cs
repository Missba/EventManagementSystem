namespace EventManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignRoles",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        Role = c.String(nullable: false),
                        CurrentRole = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 12),
                        EventDetails_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.EventDetails", t => t.EventDetails_EventId)
                .Index(t => t.EventDetails_EventId);
            
            CreateTable(
                "dbo.EventDetails",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.BookingEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        VenuId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Food = c.String(),
                        FoodType = c.String(),
                        Flower = c.String(),
                        Lighting = c.String(),
                        SeatingService = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventDetails", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Registrations", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.VenuDetails", t => t.VenuId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.VenuId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 12),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FBId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FBId)
                .ForeignKey("dbo.Registrations", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VenuDetails",
                c => new
                    {
                        VenuId = c.Int(nullable: false, identity: true),
                        VenuName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Cost = c.Int(nullable: false),
                        GuestCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VenuId);
            
            CreateTable(
                "dbo.EventServicesDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Food = c.String(),
                        FoodType = c.String(),
                        Flower = c.String(),
                        Lighting = c.String(),
                        SeatingService = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignRoles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "EventDetails_EventId", "dbo.EventDetails");
            DropForeignKey("dbo.BookingEvents", "VenuId", "dbo.VenuDetails");
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.Registrations");
            DropForeignKey("dbo.BookingEvents", "UserId", "dbo.Registrations");
            DropForeignKey("dbo.BookingEvents", "EventId", "dbo.EventDetails");
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropIndex("dbo.BookingEvents", new[] { "UserId" });
            DropIndex("dbo.BookingEvents", new[] { "VenuId" });
            DropIndex("dbo.BookingEvents", new[] { "EventId" });
            DropIndex("dbo.Employees", new[] { "EventDetails_EventId" });
            DropIndex("dbo.AssignRoles", new[] { "EmployeeId" });
            DropTable("dbo.EventServicesDetails");
            DropTable("dbo.VenuDetails");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Registrations");
            DropTable("dbo.BookingEvents");
            DropTable("dbo.EventDetails");
            DropTable("dbo.Employees");
            DropTable("dbo.AssignRoles");
        }
    }
}
