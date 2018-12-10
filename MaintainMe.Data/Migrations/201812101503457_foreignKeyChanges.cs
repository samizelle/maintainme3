namespace MaintainMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeyChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrder", "CarOwner_CarOwnerId", c => c.Int());
            CreateIndex("dbo.WorkOrder", "CarOwner_CarOwnerId");
            AddForeignKey("dbo.WorkOrder", "CarOwner_CarOwnerId", "dbo.CarOwner", "CarOwnerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrder", "CarOwner_CarOwnerId", "dbo.CarOwner");
            DropIndex("dbo.WorkOrder", new[] { "CarOwner_CarOwnerId" });
            DropColumn("dbo.WorkOrder", "CarOwner_CarOwnerId");
        }
    }
}
