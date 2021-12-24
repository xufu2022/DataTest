using InDepth.Relationship.ReDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InDepth.Relationship.Configurations
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
