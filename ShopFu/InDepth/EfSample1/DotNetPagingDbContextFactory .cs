using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EfSample1;

public class DotNetPagingDbContextFactory : IDesignTimeDbContextFactory<DotNetPagingDbContext>
{


    public DotNetPagingDbContext CreateDbContext()
    {
        return CreateDbContext(null);
    }

    public DotNetPagingDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
        var builder = new DbContextOptionsBuilder<DotNetPagingDbContext>().UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"));
        return new DotNetPagingDbContext(builder.Options);
    }


}

