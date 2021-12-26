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
    public class BookDetailConfig : IEntityTypeConfiguration<BookDetail>
    {
        public void Configure
            (EntityTypeBuilder<BookDetail> entity)
        {
            entity.ToTable("Books");
        }
    }
}
