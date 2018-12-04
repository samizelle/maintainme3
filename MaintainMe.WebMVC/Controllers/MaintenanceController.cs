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
    [Authorize]
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintenanceService(userId);
            var model = new MaintenanceListItem();
            return View(model);
        }

        // GET: Maintenance Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maintenance Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaintenanceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMaintenanceService();

            if (service.CreateMaintenance(model))
            {
                TempData["SaveResult"] = "Maintenance event created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Maintenance event not created");

            return View(model);
        }

        // GET Maintenance Details
        public ActionResult Details(int id)
        {
            var svc = CreateMaintenanceService();
            var model = svc.GetMaintenanceById(id);

            return View(model);
        }

        // GET Maintenance Edit
        public ActionResult Edit(int id)
        {
            var service = CreateMaintenanceService();
            var detail = service.GetMaintenanceById(id);
            var model =
                new MaintenanceEdit
                {
                    MaintenanceId = detail.MaintenanceId,
                    MaintenanceMileage = detail.MaintenanceMileage,
                    MaintenanceDescription = detail.MaintenanceDescription
                };
            return View(model);
        }

        // POST Maintenance Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MaintenanceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MaintenanceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMaintenanceService();

            if (service.UpdateMaintenance(model))
            {
                TempData["SaveResult"] = "Maintenance Event was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Maintenance Event was not updated");
            return View(model);
        }

        private MaintenanceService CreateMaintenanceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintenanceService(userId);
            return service;
        }
    }
}