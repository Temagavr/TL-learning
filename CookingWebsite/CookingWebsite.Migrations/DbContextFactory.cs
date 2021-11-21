using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using CookingWebsite.Infrastructure.Foundation;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CookingWebsite.Migrations
{
    public class DbContextFactory
    {
        public CookingWebsiteDbContext CreateDbContext( string[] _ )
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath( Directory.GetCurrentDirectory() )
                .AddJsonFile( "appsettings.json" )
                .AddJsonFile( $"appsettings.{Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" )}.json", true )
                .AddEnvironmentVariables();

            var config = builder.Build();
            var connectionString = config.GetConnectionString( "CookingWebsiteConnection" );
            var optionsBuilder = new DbContextOptionsBuilder<CookingWebsiteDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new CookingWebsiteDbContext( optionsBuilder.Options );
        }
    }
}
