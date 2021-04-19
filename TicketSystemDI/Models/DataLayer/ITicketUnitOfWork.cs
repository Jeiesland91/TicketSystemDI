namespace TicketSystem.Models
{
    public interface ITicketUnitOfWork
    {
        public IRepository<Point> Points { get; }
        public IRepository<Sprint> Sprints { get; }
        public IRepository<Status> Statuses { get; }
        public IRepository<Ticket> Tickets { get; }

        public void Save();
    }
}
