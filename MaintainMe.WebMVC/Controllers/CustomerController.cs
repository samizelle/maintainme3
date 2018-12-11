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
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            var model = service.GetCustomers();

            return View(model);
        }

        // GET: Customer Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Customer not created");

            return View(model);
        }

        // GET Customer Detail
        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        // Car Detail by Customer
        public ActionResult CustomerCarIndex(int customerId)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerCar(customerId);

            return View(model);
        }

        // GET Customer Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model = new CustomerEdit
            {
                CustomerId = detail.CustomerId,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                Address = detail.Address,
                CityStZip = detail.CityStZip
            };
            return View(model);
        }

        // POST Customer Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "The customer was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The customer was not updated");
            return View(model);
        }

        // GET Customer Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        //POST Customer Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();
            service.DeleteCustomer(id);

            TempData["SaveResult"] = "The customer was deleted";

            return RedirectToAction("Index");
        }

        private CustomerService CreateCustomerService()
        {
            return new CustomerService(Guid.Parse(User.Identity.GetUserId()));

        }
    }
}