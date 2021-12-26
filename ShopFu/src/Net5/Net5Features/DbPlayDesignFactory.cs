using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Net5Features.NoRelationProperties;
using Net5Features.Relationship;

namespace Net5Features;

public class DbDesignFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
{
    public TContext CreateDbContext()
    {
        return CreateDbContext(null);
    }

    public TContext CreateDbContext(string[] args)
    {
        //var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
        var connString =
            "server=.;database=placeholder;Integrated Security=true;".Replace("placeholder", typeof(TContext).Name);
        var builder = new DbContextOptionsBuilder<TContext>().UseSqlServer(
            connString);
        return (TContext)Activator.CreateInstance(typeof(TContext), new object[] { builder.Options });
    }

}

public class NoRelationDbContextFactory : DbDesignFactory<NoRelationDbContext> { }
public class SplitOwnContextFactory : DbDesignFactory<SplitOwnContext> { }
public class RelationShipContextFactory : DbDesignFactory<RelationShipContext> { }



