using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class StatusController : Controller
    {
        private IRepository<Status> statuses { get; set; }
        public StatusController(IRepository<Status> rep) => statuses = rep;

        public ViewResult Index()
        {
            var options = new QueryOptions<Status>
            {
                OrderBy = p => p.Name
            };
            return View(statuses.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Status status)
        {
            if (ModelState.IsValid)
            {
                statuses.Insert(status);
                statuses.Save();

                TempData["msg"] = $"{status.Name} added to list of statuses";

                return RedirectToAction("Index");
            }
            else
            {
                return View(status);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(statuses.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Status status)
        {
            status = statuses.Get(status.StatusId); // so can get status name for notification message

            statuses.Delete(status);
            statuses.Save();

            TempData["msg"] = $"{status.StatusId} removed from list of statuses";

            return RedirectToAction("Index");
        }
    }
}
