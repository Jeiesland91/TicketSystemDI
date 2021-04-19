using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class HomeController : Controller
    {
        private IHttpContextAccessor http { get; set; }
        private ITicketUnitOfWork data { get; set; }

        public HomeController(ITicketUnitOfWork unit, IHttpContextAccessor ctx)
        {
            data = unit;
            http = ctx;
        }

        public ViewResult Index(int id)
        {
           // options for Tickets query
            var ticketOptions = new QueryOptions<Ticket>
            {
                Includes = "Sprint, Status, Point"
            };

            // order by ticket if no ticket id. Otherwise, filter by Ticket.
            if (id == 0)
            {
                ticketOptions.OrderBy = t => t.TicketId;
            }
            else
            {
                ticketOptions.Where = t => t.TicketId == id;
            }

            // execute queries
            return View(data.Tickets.List(ticketOptions));
        }
    }
}
