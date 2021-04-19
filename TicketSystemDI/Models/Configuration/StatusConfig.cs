using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketSystem.Models.Configuration
{
    internal class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity)
        {
            //entity.HasOne(t => t.Ticket)
            //    .WithMany(t => t.Classes)
            //    .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(
                new Status { StatusId = "1", Name = "To Do" },
                new Status { StatusId = "2", Name = "In Progress" },
                new Status { StatusId = "3", Name = "Quality Assurance" },
                new Status { StatusId = "4", Name = "Done" }
            );
        }
    }
}
