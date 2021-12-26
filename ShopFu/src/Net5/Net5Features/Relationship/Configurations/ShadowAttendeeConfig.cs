using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net5Features.Relationship.ReDomain;

namespace Net5Features.Relationship.Configurations
{
    public class ShadowAttendeeConfig : IEntityTypeConfiguration<ShadowAttendee>
    {
        public void Configure
            (EntityTypeBuilder<ShadowAttendee> entity)
        {
            entity.HasOne(p => p.TicketOption1)
                .WithOne(p => p.Attendee)
                .HasForeignKey<ShadowAttendee>();
            entity.HasOne(p => p.TicketOption2)
                .WithOne(p => p.Attendee)
                .HasForeignKey<TicketOption2>();
        }
    }
}
