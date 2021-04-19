using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketSystem.Models.Configuration
{
    internal class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> entity)
        {
            //entity.HasOne(p => p.Point)
            //    .WithOne(st => st.Status)
            //    .
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
