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
    public class CarController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            CarService carService = CreateCarService();
            var cars = carService.GetCars();
            return Ok(cars);
        }

        public IHttpActionResult Get(int id)
        {
            CarService carService = CreateCarService();
            var car = carService.GetCarById(id);
            return Ok(car);
        }

        public IHttpActionResult Post(CarCreate car)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCarService();

            if (!service.CreateCar(car))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(CarEdit car)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCarService();

            if (!service.UpdateCar(car))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCarService();

            if (!service.DeleteCar(id))
                return InternalServerError();

            return Ok();
        }

        private CarService CreateCarService()
        {
            return new CarService(Guid.Parse(User.Identity.GetUserId()));
        }


    }
}
