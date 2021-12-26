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
    public class EmployeeShortFkConfig : IEntityTypeConfiguration<EmployeeShortFk>
    {
        public void Configure
            (EntityTypeBuilder<EmployeeShortFk> entity)
        {
            entity.HasOne(p => p.Manager)
                .WithOne()
                .HasForeignKey<EmployeeShortFk>(p => p.ManagerId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
