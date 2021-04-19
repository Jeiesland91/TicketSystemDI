using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class TicketController : Controller
    {
        private IHttpContextAccessor http { get; set; }
        private ITicketUnitOfWork data { get; set; }

        public TicketController(ITicketUnitOfWork rep, IHttpContextAccessor ctx)
        {
            data = rep;
            http = ctx;
        }

        public RedirectToActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var c = this.GetTicket(id);
            return View("Add", c);
        }

        [HttpPost]
        public IActionResult Add(Ticket t)
        {
            string operation = (t.TicketId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (t.TicketId == 0)
                    data.Tickets.Insert(t);
                else
                    data.Tickets.Update(t);
                data.Tickets.Save();

                string verb = (operation == "Add") ? "added" : "updated";
                TempData["msg"] = $"{t.Description} {verb}";

                return this.GoToTickets();
            }
            else
            {
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var c = this.GetTicket(id);
            return View(c);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Ticket t)
        {
            t = data.Tickets.Get(t.TicketId); // so can get ticket description for notification message

            data.Tickets.Delete(t);
            data.Tickets.Save();

            TempData["msg"] = $"{t.Description} deleted";

            return this.GoToTickets();
        }

        // private helper methods
        private Ticket GetTicket(int id)
        {
            var ticketOptions = new QueryOptions<Ticket>
            {
                Includes = "Sprint, Status, Point",
                Where = t => t.TicketId == id
            };
            return data.Tickets.Get(ticketOptions);
        }

        private void LoadViewBag(string operation)
        {
            ViewBag.Points = data.Points.List(new QueryOptions<Point>
            {
                OrderBy = p => p.PointId
            });
            ViewBag.Statuses = data.Statuses.List(new QueryOptions<Status>
            {
                OrderBy = s => s.Name
            });
            ViewBag.Sprints = data.Sprints.List(new QueryOptions<Sprint>
            {
                OrderBy = s => s.SprintNumber
            });

            ViewBag.Operation = operation;
        }

        private RedirectToActionResult GoToTickets()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
