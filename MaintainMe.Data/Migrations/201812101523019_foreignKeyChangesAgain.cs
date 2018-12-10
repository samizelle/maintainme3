namespace MaintainMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeyChangesAgain : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.WorkOrder", name: "CarOwner_CarOwnerId", newName: "CarOwnerId");
            RenameIndex(table: "dbo.WorkOrder", name: "IX_CarOwner_CarOwnerId", newName: "IX_CarOwnerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.WorkOrder", name: "IX_CarOwnerId", newName: "IX_CarOwner_CarOwnerId");
            RenameColumn(table: "dbo.WorkOrder", name: "CarOwnerId", newName: "CarOwner_CarOwnerId");
        }
    }
}
