using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CookingWebsite.Infrastructure.Foundation
{
    public class DesignContextFactory
    {
        public CookingWebsiteDbContext CreateDbContext (string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            var connectionString = config.GetConnectionString("CookingWebsiteConnection");
            var optionsBuilder = new DbContextOptionsBuilder<CookingWebsiteDbContext>();

            //optionsBuilder.UseSqlServer(connectionString);

            return new CookingWebsiteDbContext(optionsBuilder.Options);
        }
    }
}
