namespace MaintainMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Car", "FirstName", c => c.String());
            AddColumn("dbo.Car", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Car", "LastName");
            DropColumn("dbo.Car", "FirstName");
        }
    }
}
