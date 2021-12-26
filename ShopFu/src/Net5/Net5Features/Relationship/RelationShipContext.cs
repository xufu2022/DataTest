using Microsoft.EntityFrameworkCore;
using Net5Features.Relationship.Configurations;
using Net5Features.Relationship.ReDomain;

namespace Net5Features.Relationship
{
    public class RelationShipContext: DbContext
    {
        public RelationShipContext(DbContextOptions<RelationShipContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AttendeeConfig());
            modelBuilder.ApplyConfiguration(new ShadowAttendeeConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new EmployeeShortFkConfig());
            modelBuilder.ApplyConfiguration(new DeletePrincipalConfig());
            modelBuilder.ApplyConfiguration(new PaymentConfig());

            modelBuilder.Entity<ShippingContainer>().ToTable(nameof(ShippingContainer));
            modelBuilder.Entity<PlasticContainer>().ToTable(nameof(PlasticContainer));
        }
    }
}
