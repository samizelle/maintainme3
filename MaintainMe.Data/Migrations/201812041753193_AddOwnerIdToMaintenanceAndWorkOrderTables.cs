namespace MaintainMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnerIdToMaintenanceAndWorkOrderTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrder", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Maintenance", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Maintenance", "OwnerId");
            DropColumn("dbo.WorkOrder", "OwnerId");
        }
    }
}
