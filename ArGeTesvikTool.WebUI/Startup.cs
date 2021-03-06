using ArGeTesvikTool.Business.ValidationRules.CustomValidation;
using ArGeTesvikTool.WebUI.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ArGeTesvikTool.WebUI
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(_configuration["ConnectionStrings:DbConnection"]);
            });

            services.AddIdentity<AppIdentityUser, AppIdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
            })
                .AddPasswordValidator<PasswordValidator>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            CookieBuilder cookieBuilder = new()
            {
                Name = "AgmIdentity",
                HttpOnly = false,
                SameSite = SameSiteMode.Lax,
                SecurePolicy = CookieSecurePolicy.SameAsRequest,
            };

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/giris");
                options.LogoutPath = new PathString("/cikis");
                options.AccessDeniedPath = new PathString("/erisim-ret");
                //options.Cookie = cookieBuilder;
                //options.ExpireTimeSpan = TimeSpan.FromDays(30);
                //options.SlidingExpiration = true;
            });

            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
                option.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            services
                .AddSession()
                .AddDistributedMemoryCache()
                .AddControllersWithViews()
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Brings information page on pages that do not return content.
                app.UseStatusCodePages();
            }

            if (!env.IsDevelopment()) {
                app.UseExceptionHandler("/hata/500");
                app.UseStatusCodePagesWithReExecute("/hata/{0}");
            }
            app.UseStaticFiles();
            app.UseSession();
            // Middleware used for microsoft identity
            app.UseAuthentication();
            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Authentication}/{action=Login}");
        }
    }
}
