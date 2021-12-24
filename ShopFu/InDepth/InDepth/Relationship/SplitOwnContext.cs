using InDepth.Relationship.Configurations;
using InDepth.Relationship.ReDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InDepth.Relationship
{
    public class SplitOwnContext:DbContext
    {
        public SplitOwnContext(DbContextOptions<SplitOwnContext> options) : base(options)
        {}
        public DbSet<BookSummary> BookSummaries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookSummaryConfig());
            modelBuilder.ApplyConfiguration(new BookDetailConfig());
            modelBuilder.ApplyConfiguration(new OrderInfoConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

    }
}
