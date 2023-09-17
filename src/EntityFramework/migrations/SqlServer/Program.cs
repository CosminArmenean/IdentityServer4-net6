
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Add services to the container.
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString(name: "db");

var identityBuilder = builder.Services.AddIdentityServer()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseMySql(connectionString, ServerVersion.AutoDetect());
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseMySql(connectionString, ServerVersion.AutoDetect());
    });

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.Run();

//public static void Main(string[] args)
//        {
//            var host = BuildWebHost(args);
//            SeedData.EnsureSeedData(host.Services);
//        }

//        public static IWebHost BuildWebHost(string[] args) =>
//            WebHost.CreateDefaultBuilder(args)
//                .UseStartup<Startup>()
//                .Build();
//    }
//}
//public class Startup
//{
//    public IConfiguration Configuration { get; }

//    public Startup(IConfiguration config)
//    {
//        Configuration = config;
//    }

//    public void ConfigureServices(IServiceCollection services)
//    {
//        var cn = Configuration.GetConnectionString("db");

//        services.AddIdentityServer()
//            .AddConfigurationStore(options => {
//                options.ConfigureDbContext = b => b.UseSqlServer(cn);
//            })
//            .AddOperationalStore(options => {
//                options.ConfigureDbContext = b => b.UseSqlServer(cn);
//            });
//    }

//    public void Configure(IApplicationBuilder app)
//    {
//    }
//}
//}
