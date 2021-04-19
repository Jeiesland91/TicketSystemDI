using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class PointController : Controller
    {
        private IRepository<Point> points { get; set; }
        public PointController(IRepository<Point> rep) => points = rep;

        public ViewResult Index()
        {
            var options = new QueryOptions<Point>
            {
                OrderBy = p => p.Name
            };
            return View(points.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Point point)
        {
            if (ModelState.IsValid)
            {
                points.Insert(point);
                points.Save();

                TempData["msg"] = $"{point.Name} added to list of points";

                return RedirectToAction("Index");
            }
            else
            {
                return View(point);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(points.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Point point)
        {
            point = points.Get(point.PointId); // so can get point name for notification message

            points.Delete(point);
            points.Save();

            TempData["msg"] = $"{point.PointId} removed from list of points";

            return RedirectToAction("Index");
        }
    }
}
