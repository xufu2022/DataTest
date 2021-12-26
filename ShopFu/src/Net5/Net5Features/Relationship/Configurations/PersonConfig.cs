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
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure
            (EntityTypeBuilder<Person> entity)
        {
            entity
                .HasOne(p => p.ContactInfo)
                .WithOne()
                .HasForeignKey<ContactInfo>(p => p.EmailAddress)
                .HasPrincipalKey<Person>(c => c.Email);
        }
    }
}
