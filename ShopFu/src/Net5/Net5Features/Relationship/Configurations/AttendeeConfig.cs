using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net5Features.Relationship.ReDomain;

namespace Net5Features.Relationship.Configurations;

public class AttendeeConfig: IEntityTypeConfiguration<Attendee>
{
    public void Configure(EntityTypeBuilder<Attendee> builder)
    {
        builder.HasOne(x => x.Optional)
            .WithOne(x => x.Attend)
            .HasForeignKey<Attendee>("OptionalTrackId");

        builder.HasOne(x => x.Required)
            .WithOne(x => x.Attend)
            .HasForeignKey<Attendee>("MyShadowFk").IsRequired(); 
    }
}