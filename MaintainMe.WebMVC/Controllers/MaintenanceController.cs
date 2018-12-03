using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaintainMe.Models;

namespace MaintainMe.WebMVC.Controllers
{
    [Authorize]
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
        public ActionResult Index()
        {
            var model = new MaintenanceListItem[0];
            return View(model);
        }

        // GET: Maintenance Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maintenance Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaintenanceCreate model)
        {
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }
    }

}