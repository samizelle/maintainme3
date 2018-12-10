using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Data;
using MaintainMe.Models;

namespace MaintainMe.Services
{
    public class WorkOrderService
    {
        private readonly Guid _userId;

        public WorkOrderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWorkOrder(WorkOrderCreate model)
        {
            var entity =
                new WorkOrder()
                { 
                    OwnerId = _userId,
                    CarId = model.CarId, 
                    CarOwnerId = model.CarOwnerId,
                    CarMileage = model.CarMileage,
                    WorkOrderDetail = model.WorkOrderDetail,
                    WorkOrderDate = model.WorkOrderDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.WorkOrders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkOrderListItem> GetWorkOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .WorkOrders
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new WorkOrderListItem
                                {
                                    WorkOrderId = e.WorkOrderId,
                                    CustomerLastName = e.CarOwner.LastName,
                                    CarId = e.CarId,
                                    CarMileage = e.CarMileage,
                                    WorkOrderDetail = e.WorkOrderDetail,
                                    WorkOrderDate = e.WorkOrderDate
                                }
                        );

                return query.ToArray();
            }
        }

        public WorkOrderDetailModel GetWorkOrderById(int WorkOrderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkOrders
                        .Single(e => e.WorkOrderId == WorkOrderId && e.OwnerId == _userId);
                return
                    new WorkOrderDetailModel
                    {
                        WorkOrderId = entity.WorkOrderId,
                        CustomerLastName = entity.CarOwner.LastName,
                        CarMileage = entity.CarMileage,
                        WorkOrderDetail = entity.WorkOrderDetail,
                        WorkOrderDate = entity.WorkOrderDate
                    };
            }
        }

        public bool UpdateWorkOrder(WorkOrderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkOrders
                        .Single(e => e.WorkOrderId == model.WorkOrderId && e.OwnerId == _userId);

                entity.CarId = model.CarId;
                entity.CarMileage = model.CarMileage;
                entity.WorkOrderDetail = model.WorkOrderDetail;
                entity.WorkOrderDate = model.WorkOrderDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWorkOrder(int workOrderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkOrders
                        .Single(e => e.WorkOrderId == workOrderId && e.OwnerId == _userId);

                ctx.WorkOrders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
