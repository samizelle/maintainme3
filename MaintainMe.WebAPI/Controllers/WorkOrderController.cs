using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MaintainMe.Models;
using MaintainMe.Services;
using Microsoft.AspNet.Identity;

namespace MaintainMe.WebAPI.Controllers
{
    [Authorize]
    public class WorkOrderController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            WorkOrderService workOrderService = CreateWorkOrderService();
            var workOrder = workOrderService.GetWorkOrders();
            return Ok(workOrder);
        }

        public IHttpActionResult Get(int id)
        {
            WorkOrderService workOrderService = CreateWorkOrderService();
            var workOrder = workOrderService.GetWorkOrderById(id);
            return Ok(workOrder);
        }

        public IHttpActionResult Post(WorkOrderCreate workOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateWorkOrderService();

            if (!service.CreateWorkOrder(workOrder))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(WorkOrderEdit workOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateWorkOrderService();

            if (!service.UpdateWorkOrder(workOrder))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateWorkOrderService();

            if (!service.DeleteWorkOrder(id))
                return InternalServerError();

            return Ok();
        }

        private WorkOrderService CreateWorkOrderService()
        {
            return new WorkOrderService(Guid.Parse(User.Identity.GetUserId()));
        }
    }
}
