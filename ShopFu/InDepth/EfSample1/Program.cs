// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using EfSample1;

using (var context = new DotNetPagingDbContextFactory().CreateDbContext())
{
    var releases = context.PressReleases.ToList();

    foreach (var release in releases)
    {
        Console.WriteLine(release.Title);
    }
}

Console.WriteLine("\r\nPress any key to continue ...");
Console.Read();

Console.WriteLine("Hello, World!");
