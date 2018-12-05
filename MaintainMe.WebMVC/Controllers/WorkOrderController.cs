using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaintainMe.Models;
using MaintainMe.Services;
using Microsoft.AspNet.Identity;

namespace MaintainMe.WebMVC.Controllers
{
    public class WorkOrderController : Controller
    {
        // GET: WorkOrder
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkOrderService(userId);
            var model = service.GetWorkOrders();

            return View(model);
        }

        // GET: WorkOrder Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkOrder Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkOrderCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWorkOrderService();

            if (service.CreateWorkOrder(model))
            {
                TempData["SaveResult"] = "WorkOrder created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "WorkOrder not created");

            return View(model);
        }

        // GET WorkOrder Details
        public ActionResult Details(int id)
        {
            var svc = CreateWorkOrderService();
            var model = svc.GetWorkOrderById(id);

            return View(model);
        }

        // GET WorkOrder Edit
        public ActionResult Edit(int id)
        {
            var service = CreateWorkOrderService();
            var detail = service.GetWorkOrderById(id);
            var model =
                new WorkOrderEdit
                {
                    CarId = detail.CarId,
                    CarMileage = detail.CarMileage,
                    WorkOrderDetail = detail.WorkOrderDetail,
                    WorkOrderDate = detail.WorkOrderDate
                };
            return View(model);
        }

        // POST WorkOrder Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkOrderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WorkOrderId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateWorkOrderService();

            if (service.UpdateWorkOrder(model))
            {
                TempData["SaveResult"] = "WorkOrder was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "WorkOrder was not updated");
            return View(model);
        }

        // GET Car Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateWorkOrderService();
            var model = svc.GetWorkOrderById(id);

            return View(model);
        }

        //POST WorkOrder Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWorkOrderService();
            service.DeleteWorkOrder(id);

            TempData["SaveResult"] = "Work Order was deleted";

            return RedirectToAction("Index");
        }

        private WorkOrderService CreateWorkOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkOrderService(userId);
            return service;
        }
    }
}