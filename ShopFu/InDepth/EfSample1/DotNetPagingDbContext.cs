using System;
using Microsoft.EntityFrameworkCore;

namespace EfSample1;

public class DotNetPagingDbContext : DbContext
{
    public DotNetPagingDbContext(DbContextOptions<DotNetPagingDbContext> options) : base(options)
    {
        
    }
    public DbSet<PressRelease> PressReleases { get; set; }
}

public class PressRelease
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public DateTime ReleaseDate { get; set; }
}