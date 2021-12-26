using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net5Features.Relationship.ReDomain;

namespace Net5Features.Relationship.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure
            (EntityTypeBuilder<User> entity)
        {
            entity
                .OwnsOne(e => e.HomeAddress)
                .ToTable("Addresses");
        }
    }
}
