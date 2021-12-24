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
    public class BookSummaryConfig : IEntityTypeConfiguration<BookSummary>
    {
        public void Configure
            (EntityTypeBuilder<BookSummary> entity)
        {
            entity
                .HasOne(e => e.Details).WithOne()
                .HasForeignKey<BookDetail>(e => e.BookDetailId);
            entity.ToTable("Books");
        }
    }
}
