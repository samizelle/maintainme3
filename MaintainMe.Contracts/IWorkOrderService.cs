using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Models;

namespace MaintainMe.Contracts
{
    public interface IWorkOrderService
    {
        bool CreateWorkOrder(WorkOrderCreate model);
        IEnumerable<WorkOrderListItem> GetWorkOrders();
        WorkOrderDetailModel GetWorkOrderById(int WorkOrderId);
        bool UpdateWorkOrder(WorkOrderEdit model);
        bool DeleteWorkOrder(int workOrderId);

    }
}
