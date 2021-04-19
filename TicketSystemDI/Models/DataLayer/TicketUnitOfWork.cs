using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketSystem.Models
{
    public class TicketUnitOfWork : ITicketUnitOfWork
    {
        private TicketContext context { get; set; }
        public TicketUnitOfWork(TicketContext ctx) => context = ctx;
        
        private IRepository<Point> pointData;
        public IRepository<Point> Points
        {
            get
            {
                if (pointData == null)
                    pointData = new Repository<Point>(context);
                return pointData;
            }
        }

        private IRepository<Sprint> sprintData;
        public IRepository<Sprint> Sprints
        {
            get
            {
                if (sprintData == null)
                    sprintData = new Repository<Sprint>(context);
                return sprintData;
            }
        }

        private IRepository<Status> statusData;
        public IRepository<Status> Statuses
        {
            get
            {
                if (statusData == null)
                    statusData = new Repository<Status>(context);
                return statusData;
            }
        }

        private IRepository<Ticket> ticketData;
        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketData == null)
                    ticketData = new Repository<Ticket>(context);
                return ticketData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
