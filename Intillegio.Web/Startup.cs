﻿using System;
using AutoMapper;
using Intillegio.Data.Data;
using Intillegio.Data.Seeding;
using Intillegio.Emails;
using Intillegio.Emails.Contracts;
using Intillegio.Models;
using Intillegio.Services;
using Intillegio.Services.Contracts;
using Intillegio.Services.Emails;
using Intillegio.Services.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Intillegio.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IEmailMessage, EmailMessage>();

            services.AddDbContext<IntillegioContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IntillegioUser, IdentityRole>(options =>
                {
                    options.Lockout.DefaultLockoutTimeSpan = new TimeSpan(1, 0, 0);
                    options.Lockout.MaxFailedAccessAttempts = 10;
                })
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<IntillegioContext>()
                .AddDefaultTokenProviders();

            RegisterGlobalServices(services);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 443;
            });


            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment() || env.IsEnvironment("QA"))
            {
                app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions());
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            RoleSeeder.SeedRoles(serviceProvider);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Administration",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void RegisterGlobalServices(IServiceCollection services)
        {
            services.AddScoped<IProjectsService, ProjectsService>();
            services.AddScoped<IClientsService, ClientsService>();
            services.AddScoped<ISolutionsService, SolutionsService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IAboutService, AboutService>();
        }
    }
}
