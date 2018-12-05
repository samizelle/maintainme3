namespace MaintainMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDateformat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkOrder", "WorkOrderDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkOrder", "WorkOrderDate", c => c.DateTime(nullable: false));
        }
    }
}
