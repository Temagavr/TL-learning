using CookingWebsite.Application;
using CookingWebsite.Application.Files;
using CookingWebsite.Infrastructure;
using CookingWebsite.Infrastructure.Foundation;
using CookingWebsite.Modules.AccountModule;
using CookingWebsite.Modules.HomeModule;
using CookingWebsite.Modules.RecipeCreateModule;
using CookingWebsite.Modules.RecipeDeleteModule;
using CookingWebsite.Modules.RecipeDetailsModule;
using CookingWebsite.Modules.RecipeModule;
using CookingWebsite.Modules.RecipeUpdateModule;
using CookingWebsite.Modules.SearchRecipeModule;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CookingWebsite
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services
                .AddApplication()
                .AddAccountModule()
                .AddHomeModule()
                .AddRecipeModule()
                .AddRecipeDeleteModule()
                .AddRecipeDetailsModule()
                .AddRecipeCreateModule()
                .AddRecipeUpdateModule()
                .AddRecipeSearchModule()
                .AddRepositories();

            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/account/login");
                });
            

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles( configuration =>
             {
                 configuration.RootPath = "ClientApp/dist";
             } );

            services.AddDbContext<CookingWebsiteDbContext>(
               x => x.UseSqlServer(Configuration.GetConnectionString("CookingWebsiteConnection"),
               x => x.MigrationsAssembly( "CookingWebsite.Migrations" ) )
            );

            services.AddSingleton(Configuration.GetSection("Storage").Get<FileStorageSettings>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            //Delete this 4 strings in future
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CookingWebsiteDbContext>();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler( "/Error" );
            }

            app.UseStaticFiles();
            if ( !env.IsDevelopment() )
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();    
            app.UseAuthorization();     

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller}/{action=Index}/{id?}" );
             } );

            app.UseSpa( spa =>
             {
                 // To learn more about options for serving an Angular SPA from ASP.NET Core,
                 // see https://go.microsoft.com/fwlink/?linkid=864501

                 spa.Options.SourcePath = "ClientApp";

                 if ( env.IsDevelopment() )
                 {
                     spa.UseAngularCliServer( npmScript: "start" );
                 }
             } );
        }
    }
}
