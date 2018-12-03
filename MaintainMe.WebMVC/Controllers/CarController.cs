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
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CarService(userId);
            var model = service.GetCars();

            return View(model);
        }

        // GET: Car Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCarService();

            if (service.CreateCar(model))
            {
                TempData["SaveResult"] = "Your note was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Car was not created");

            return View(model);
        }

        private CarService CreateCarService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CarService(userId);
            return service;
        }
    }
}