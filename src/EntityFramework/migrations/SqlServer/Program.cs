
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlServer;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Add services to the container.
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString(name: "db");

var identityBuilder = builder.Services.AddIdentityServer()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Seed the data into the database.
SeedData.EnsureSeedData(app.Services);

app.Run();

//public static void Main(string[] args)
//{
//    var host = BuildWebHost(args);
//    SeedData.EnsureSeedData(host.Services);
//}

//public static IWebHost BuildWebHost(string[] args) =>
//    WebHost.CreateDefaultBuilder(args)
//        .UseStartup<Startup>()
//        .Build();
//    }

