namespace MaintainMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class barebones : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Car", "FirstName");
            DropColumn("dbo.Car", "LastName");
            DropColumn("dbo.Car", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Car", "FullName", c => c.String());
            AddColumn("dbo.Car", "LastName", c => c.String());
            AddColumn("dbo.Car", "FirstName", c => c.String());
        }
    }
}
