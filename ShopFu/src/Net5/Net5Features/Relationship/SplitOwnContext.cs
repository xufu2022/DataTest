using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Net5Features.Relationship.Configurations;
using Net5Features.Relationship.ReDomain;

namespace Net5Features.Relationship
{
    public class SplitOwnContext:DbContext
    {
        public SplitOwnContext(DbContextOptions<SplitOwnContext> options) : base(options)
        {}

        public DbSet<BookSummary> BookSummaries { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookSummaryConfig());
            modelBuilder.ApplyConfiguration(new BookDetailConfig());
            modelBuilder.ApplyConfiguration(new OrderInfoConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

    }
}
