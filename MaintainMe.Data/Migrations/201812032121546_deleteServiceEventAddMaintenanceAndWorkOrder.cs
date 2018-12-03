namespace MaintainMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteServiceEventAddMaintenanceAndWorkOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkOrder",
                c => new
                    {
                        WorkOrderId = c.Int(nullable: false, identity: true),
                        MaintId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        CarMileage = c.Int(nullable: false),
                        WorkOrderDate = c.DateTime(nullable: false),
                        Maintenance_MaintenanceId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkOrderId)
                .ForeignKey("dbo.Car", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Maintenance", t => t.Maintenance_MaintenanceId)
                .Index(t => t.CarId)
                .Index(t => t.Maintenance_MaintenanceId);
            
            CreateTable(
                "dbo.Maintenance",
                c => new
                    {
                        MaintenanceId = c.Int(nullable: false, identity: true),
                        MaintenanceMileage = c.Int(nullable: false),
                        MaintenanceDescription = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.MaintenanceId);
            
            DropTable("dbo.ServiceEvent");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServiceEvent",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        ServiceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            DropForeignKey("dbo.WorkOrder", "Maintenance_MaintenanceId", "dbo.Maintenance");
            DropForeignKey("dbo.WorkOrder", "CarId", "dbo.Car");
            DropIndex("dbo.WorkOrder", new[] { "Maintenance_MaintenanceId" });
            DropIndex("dbo.WorkOrder", new[] { "CarId" });
            DropTable("dbo.Maintenance");
            DropTable("dbo.WorkOrder");
        }
    }
}
