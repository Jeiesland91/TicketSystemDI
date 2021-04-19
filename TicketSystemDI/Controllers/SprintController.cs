using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class SprintController : Controller
    {
        private IRepository<Sprint> sprints { get; set; }
        public SprintController(IRepository<Sprint> rep) => sprints = rep;

        public ViewResult Index()
        {
            var options = new QueryOptions<Sprint>
            {
                OrderBy = s => s.SprintNumber
            };
            return View(sprints.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Sprint sprint)
        {
            if (ModelState.IsValid)
            {
                sprints.Insert(sprint);
                sprints.Save();

                TempData["msg"] = $"{sprint.SprintNumber} added to list of sprints";

                return RedirectToAction("Index");
            }
            else
            {
                return View(sprint);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(sprints.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Sprint sprint)
        {
            sprint = sprints.Get(sprint.SprintId); // so can get sprint number for notification message

            sprints.Delete(sprint);
            sprints.Save();

            TempData["msg"] = $"{sprint.SprintId} removed from list of sprints";

            return RedirectToAction("Index");
        }
    }
}
