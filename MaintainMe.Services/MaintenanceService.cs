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
        private readonly Guid _userId;

        public MaintenanceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMaintenance(MaintenanceCreate model)
        {
            var entity =
                new Maintenance()
                {
                    // OwnerId = _userId,
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

        public MaintenanceDetail GetMaintenanceById(int maintenanceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Maintenances
                        .Single(e => e.MaintenanceId == maintenanceId);
                return
                    new MaintenanceDetail
                    {
                        MaintenanceId = entity.MaintenanceId,
                        MaintenanceMileage = entity.MaintenanceMileage,
                        MaintenanceDescription = entity.MaintenanceDescription
                    };
            }
        }

        public bool UpdateMaintenance(MaintenanceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Maintenances
                        .Single(e => e.MaintenanceId == model.MaintenanceId);

                entity.MaintenanceMileage = model.MaintenanceMileage;
                entity.MaintenanceDescription = model.MaintenanceDescription;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
