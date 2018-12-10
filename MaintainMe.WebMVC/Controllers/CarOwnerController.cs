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
        // GET: CarOwner
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CarOwnerService(userId);
            var model = service.GetCarOwners();

            return View(model);
        }

        // GET: CarOwner Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarOwner Create
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

        // GET CarOwner Detail
        public ActionResult Details(int id)
        {
            var svc = CreateCarOwnerService();
            var model = svc.GetCarOwnerById(id);

            return View(model);
        }

        // Car Detail by CarOwner
        public ActionResult CarOwnerCarIndex(int CarOwnerId)
        {
            var svc = CreateCarOwnerService();
            var model = svc.GetCarOwnerCar(CarOwnerId);

            return View(model);
        }

        // GET CarOwner Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCarOwnerService();
            var detail = service.GetCarOwnerById(id);
            var model = new CarOwnerEdit
            {
                CarOwnerId = detail.CarOwnerId,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                Address = detail.Address,
                CityStZip = detail.CityStZip
            };
            return View(model);
        }

        // POST CarOwner Edit
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

        // GET CarOwner Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateCarOwnerService();
            var model = svc.GetCarOwnerById(id);

            return View(model);
        }

        //POST CarOwner Delete
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
            return new CarOwnerService(Guid.Parse(User.Identity.GetUserId()));

        }
        /* 
        private CarOwnerService CreateCarOwnerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CarOwnerService(userId);
            return service;
        }*/
    }
}