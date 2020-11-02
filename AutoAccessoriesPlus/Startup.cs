using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using AutoAccessoriesPlus.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoAccessoriesPlus.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace AutoAccessoriesPlus
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AutoAccessoriesPlusDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AutoAccessoriesPlus")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true )
                .AddEntityFrameworkStores<AutoAccessoriesPlusDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            // Configure Identity Password requirements
            services.Configure<IdentityOptions>(options =>
            {
                // Specify password requirements
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;

                options.User.RequireUniqueEmail = true;                
            });

            //Set cookie settings
            services.ConfigureApplicationCookie(c =>
            {                
                c.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                c.SlidingExpiration = true;
                
                c.Events.OnSigningIn = per =>
                {
                    if (per.Properties.IsPersistent)
                    {
                        var issued = per.Properties.IssuedUtc ?? DateTimeOffset.UtcNow;
                        per.Properties.ExpiresUtc = issued.AddDays(14);
                    }
                    return Task.FromResult(0);
                };
            });

            services.AddTransient<IVehicle, VehicleService>();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
