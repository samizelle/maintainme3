namespace MaintainMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarMakeCarModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Car", "CarMake", c => c.String(nullable: false));
            AddColumn("dbo.Car", "CarModel", c => c.String(nullable: false));
            DropColumn("dbo.Car", "Make");
            DropColumn("dbo.Car", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Car", "Model", c => c.String(nullable: false));
            AddColumn("dbo.Car", "Make", c => c.String(nullable: false));
            DropColumn("dbo.Car", "CarModel");
            DropColumn("dbo.Car", "CarMake");
        }
    }
}
