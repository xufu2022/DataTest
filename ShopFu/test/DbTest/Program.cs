using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shop.Data;

//Q!: host error
//var configuration=new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
//var sqlConnection = configuration.GetConnectionString("Shop");
//configuration.GetConnectionString("Shop")
//var builder = new DbContextOptionsBuilder<ShopDbContext>();
//builder.UseSqlServer(configuration.GetConnectionString("Shop"));
//var dbContext = new ShopDbContext(builder.Options);


var dbContext = new ShopDbContext();
var categoriesCount = dbContext.Categories.Count();
Console.Write("here");
//set up connection above


