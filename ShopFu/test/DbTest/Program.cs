using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shop.Data;

IConfigurationRoot _configuration;
DbContextOptionsBuilder<ShopDbContext> _optionsBuilder;
IServiceProvider _serviceProvider;

BuildOptions();
BuildMapper();
//may need configure automapper
void BuildOptions()
{
    _configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build(); 
    _optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();
    _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Shop"));
}

void BuildMapper()
{
    var services = new ServiceCollection();
    _serviceProvider = services.BuildServiceProvider();
}

var dbContext = new ShopDbContext(_optionsBuilder.Options);
var categoriesCount = dbContext.Categories.Count();
Console.Write("here");
//set up connection above


