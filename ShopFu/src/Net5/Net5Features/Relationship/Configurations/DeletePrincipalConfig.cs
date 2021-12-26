using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net5Features.Relationship.ReDomain;

namespace Net5Features.Relationship.Configurations;

public class DeletePrincipalConfig : IEntityTypeConfiguration<DeletePrincipal>
{
    public void Configure
        (EntityTypeBuilder<DeletePrincipal> entity)
    {
        entity.HasOne(p => p.DependentSetNull)
            .WithOne()
            .HasForeignKey<DeleteDependentSetNull>(p => p.DeletePrincipalId)
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(p => p.DependentRestrict)
            .WithOne()
            .HasForeignKey<DeleteDependentRestrict>(p => p.DeletePrincipalId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(p => p.DependentCascade)
            .WithOne()
            .HasForeignKey<DeleteDependentCascade>(p => p.DeletePrincipalId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(p => p.DependentClientCascade)
            .WithOne()
            .HasForeignKey<DeleteDependentClientCascade>(p => p.DeletePrincipalId)
            .OnDelete(DeleteBehavior.ClientCascade);

        entity.HasOne(p => p.DependentClientSetNull)
            .WithOne()
            .HasForeignKey<DeleteDependentClientSetNull>(p => p.DeletePrincipalId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}