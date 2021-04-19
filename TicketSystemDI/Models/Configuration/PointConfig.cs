using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketSystem.Models.Configuration
{
    internal class PointConfig : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> entity)
        {
            //entity.HasOne(t => t.Ticket)
            //    .WithMany(t => t.Classes)
            //    .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(
                new Point { PointId = 1, Name = "1 Point" },
                new Point { PointId = 2, Name = "2 Points" },
                new Point { PointId = 3, Name = "3 Points" },
                new Point { PointId = 5, Name = "5 Points" },
                new Point { PointId = 8, Name = "8 Points" },
                new Point { PointId = 13, Name = "13 Points" },
                new Point { PointId = 21, Name = "21 Points" }
            );
        }
    }
}