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
    public class CarOwnerController : Controller
    {
        // GET: Car Owners
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CarOwnerService(userId);
            var model = service.GetCarOwners();
            
            return View(model);
        }

        // GET: Car Owner Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car Owner Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarOwnerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCarOwnerService();

            if (service.CreateCarOwner(model))
            {
                TempData["SaveResult"] = "Car Owner created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Car Owner not created");

            return View(model);
        }

        // GET Car Owner Details
        public ActionResult Details(int id)
        {
            var svc = CreateCarOwnerService();
            var model = svc.GetCarOwnerById(id);

            return View(model);
        }

        // GET Car Owner Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCarOwnerService();
            var detail = service.GetCarOwnerById(id);
            var model =
                new CarOwnerEdit
                {
                    CarOwnerId = detail.CarOwnerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Address = detail.Address,
                    CityStZip = detail.CityStZip
                };
            return View(model);
        }

        // POST Car Owner Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarOwnerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CarOwnerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCarOwnerService();

            if (service.UpdateCarOwner(model))
            {
                TempData["SaveResult"] = "The car owner was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The car owner was not updated");
            return View(model);
        }

        // GET Car Owner Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateCarOwnerService();
            var model = svc.GetCarOwnerById(id);

            return View(model);
        }

        //POST Car Owner Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCarOwnerService();
            service.DeleteCarOwner(id);

            TempData["SaveResult"] = "The car owner was deleted";

            return RedirectToAction("Index");
        }

        private CarOwnerService CreateCarOwnerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CarOwnerService(userId);
            return service;
        }
    }
}