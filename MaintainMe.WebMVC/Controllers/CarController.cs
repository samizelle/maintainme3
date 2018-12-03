﻿using System;
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

        // This is where it breaks!!!

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

        // GET Car Details
        public ActionResult Details(int id)
        {
            var svc = CreateCarService();
            var model = svc.GetCarById(id);

            return View(model);
        }

        // GET Car Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCarService();
            var detail = service.GetCarById(id);
            var model =
                new CarEdit
                {
                    CarId = detail.CarId,
                    CarMake = detail.CarMake,
                    CarModel = detail.CarModel
                };
            return View(model);
        }

        // POST Car Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if(model.CarId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCarService();

            if (service.UpdateCar(model))
            {
                TempData["SaveResult"] = "Your car was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your car was not updated");
            return View(model);
        }

        // GET Car Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateCarService();
            var model = svc.GetCarById(id);

            return View(model);
        }

        //POST Car Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCarService();
            service.DeleteCar(id);

            TempData["SaveResult"] = "Your car was deleted";

            return RedirectToAction("Index");
        }

        private CarService CreateCarService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CarService(userId);
            return service;
        }
    }
}