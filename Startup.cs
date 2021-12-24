using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OneFin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OneFin.Client;


namespace OneFin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();

            services.AddHttpClient<CFClient>();

            services.Configure<CFServiceSettings>(Configuration.GetSection(nameof(CFServiceSettings)));

            //services.AddDbContext<AppDbContext>(opt =>
            //                                    opt.UseSqlServer(Configuration.GetConnectionString("OneFin")));
            //services.AddDbContext<IdentityDbContext>(opt =>
            //                        opt.UseSqlServer(Configuration.GetConnectionString("OneFin")));


            services.AddDbContext<AppDbContext>(opt =>
                                   opt.UseInMemoryDatabase("CustomerMaster"));
            services.AddDbContext<IdentityDbContext>(opt =>
                                   opt.UseInMemoryDatabase("CustomerMaster"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.Configure<CookiePolicyOptions>(options =>
            {
             //This lambda determines whether user consent for non-essential cookies is needed for a given request.  
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddIdentity<Users, IdentityRole>()
                           .AddEntityFrameworkStores<IdentityDbContext>();

            services.AddAutoMapper(typeof(Startup));


            //services.Configure<IdentityOptions>(options =>
            //{
            // Password settings.
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    options.Lockout.MaxFailedAccessAttempts = 5;
            //    options.Lockout.AllowedForNewUsers = true;

            // User settings.
            //    options.User.AllowedUserNameCharacters =
            //    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    options.User.RequireUniqueEmail = false;
            //});

            //services.ConfigureApplicationCookie(options =>
            // {
            // Cookie settings
            //     options.Cookie.HttpOnly = true;
            //     options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            //     options.LoginPath = "/Account/Login";
            //     options.AccessDeniedPath = "/Account/AccessDenied";
            //     options.SlidingExpiration = true;
            // });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                name: "AreaSecurity",
                areaName: "Security",
                pattern: "Security/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                name: "AreaConfiguration",
                areaName: "Configuration",
                pattern: "Configuration/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                name: "AreaClairvoyance",
                areaName: "Clairvoyance",
                pattern: "Clairvoyance/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute("default", "{controller=Account}/{action=Login}");
            });
        }
    }
}
