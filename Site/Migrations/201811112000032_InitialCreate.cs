namespace Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Gabarites = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Location = c.String(),
                        Phone = c.String(),
                        Stage = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        From = c.String(),
                        To = c.String(),
                        Date = c.DateTime(nullable: false),
                        DriverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DriverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "CarId", "dbo.Cars");
            DropIndex("dbo.Orders", new[] { "DriverId" });
            DropIndex("dbo.Drivers", new[] { "CarId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Drivers");
            DropTable("dbo.Cars");
        }
    }
}
