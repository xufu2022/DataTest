using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Shop.Data;

namespace DbTest
{

    public class DbDesignFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        public TContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public TContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            var builder = new DbContextOptionsBuilder<TContext>().UseSqlServer(
                configuration.GetConnectionString("Shop"));
            return (TContext)Activator.CreateInstance(typeof(TContext), new object[] { builder.Options });
        }

    }

    public class myFactory : DbDesignFactory<ShopDbContext>{}

}
