using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Data;
using MaintainMe.Models;

namespace MaintainMe.Services
{
    public class MaintenanceService
    {
        public bool CreateMaintenance(MaintenanceCreate model)
        {
            var entity =
                new Maintenance()
                {
                    MaintenanceMileage = model.MaintenanceMileage,
                    MaintenanceDescription = model.MaintenanceDescription
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Maintenances.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MaintenanceListItem> GetMaintenances()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Maintenances
                        .Select(
                            e =>
                                new MaintenanceListItem
                                {
                                    MaintenanceId = e.MaintenanceId,
                                    MaintenanceMileage = e.MaintenanceMileage,
                                    MaintenanceDescription = e.MaintenanceDescription
                                }
                        );

                return query.ToArray();
            }
        } 
    }
}
