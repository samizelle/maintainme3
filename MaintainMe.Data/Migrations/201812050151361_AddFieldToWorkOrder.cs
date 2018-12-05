namespace MaintainMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldToWorkOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrder", "WorkOrderDetail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrder", "WorkOrderDetail");
        }
    }
}
