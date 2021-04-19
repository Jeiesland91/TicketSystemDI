using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketSystem.Models.Configuration
{
    internal class SprintConfig : IEntityTypeConfiguration<Sprint>
    {
        public void Configure(EntityTypeBuilder<Sprint> entity)
        {
            //entity.HasOne(t => t.Ticket)
            //    .WithMany(t => t.Classes)
            //    .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(
                new Sprint { SprintId = "1", SprintNumber = "Sprint 1" },
                new Sprint { SprintId = "2", SprintNumber = "Sprint 2" },
                new Sprint { SprintId = "3", SprintNumber = "Sprint 3" },
                new Sprint { SprintId = "4", SprintNumber = "Sprint 4" },
                new Sprint { SprintId = "5", SprintNumber = "Sprint 5" },
                new Sprint { SprintId = "6", SprintNumber = "Sprint 6" },
                new Sprint { SprintId = "7", SprintNumber = "Sprint 7" },
                new Sprint { SprintId = "8", SprintNumber = "Sprint 8" },
                new Sprint { SprintId = "9", SprintNumber = "Sprint 9" }
            );
        }
    }
}
