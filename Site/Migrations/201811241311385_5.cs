namespace Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Type", c => c.String());
            AlterColumn("dbo.Orders", "From", c => c.String());
            AlterColumn("dbo.Orders", "To", c => c.String());
            AlterColumn("dbo.Orders", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "To", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "From", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Type", c => c.String(nullable: false));
        }
    }
}
