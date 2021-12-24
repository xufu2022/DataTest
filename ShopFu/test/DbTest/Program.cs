using System;
using System.Linq;
using DbTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shop.Data;


using var dbContext = new myFactory().CreateDbContext();
var categoriesCount = dbContext.Categories.Count();
Console.Write("here");
//set up connection above


