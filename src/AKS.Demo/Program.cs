using AKS.Demo.Areas.Identity.Data;
using AKS.Demo.Areas.Identity.Data.Configurations;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

namespace AKS.Demo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddRazorPages();

            builder.Services.AddHealthChecks();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCors();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            var options = new HealthCheckOptions { Predicate = _ => false };

            app.MapRazorPages();
            app.MapHealthChecks("/health/ready", options);
            app.MapHealthChecks("/health/live", options);

            await app.RunAsync().ConfigureAwait(false);
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            AddAksDemoContext(builder.Services, builder.Configuration);

            builder.Services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<AksDemoContext>();

            builder.Services.AddCors(o => o.AddDefaultPolicy(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            builder.Services.AddControllersWithViews();
        }

        private static void AddAksDemoContext(IServiceCollection services, IConfiguration configuration)
        {
            var contextOptions = configuration.GetSection(AksDemoContextOptions.SectionName).Get<AksDemoContextOptions>();

            services.AddDbContext<AksDemoContext>(options => options.UseSqlServer(contextOptions.ConnectionString));
        }
    }
}
