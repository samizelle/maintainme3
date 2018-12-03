using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaintainMe.Models;

namespace MaintainMe.WebMVC.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            var model = new CarListItem[0];
            return View(model);
        }

        // GET: Car Create
        public ActionResult Create()
        {
            return View();
        }


    }
}