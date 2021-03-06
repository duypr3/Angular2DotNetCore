﻿using DAL;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using WebAPI.Base;
using WebAPI.Common;
using WebAPI.src.LoginComponent;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
           
            /*services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling =
                                                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);*/

            services.AddDbContext<DefaultDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DataMiningDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DataMiningConnection")));

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));  // before add MVC

            services.AddMvc();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.CookieHttpOnly = true;
            });


            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddScoped<IDbContextFactory, DbContextFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(ILoginService), typeof(LoginService));

            //services.AddScoped<ILoginService, LoginService>();


            //return services.AddDryIoc<Bootstrap>();  // NOT YET USING DRYIOC
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory
                                , DefaultDbContext defaultDbContext, DataMiningDbContext dataMiningDbContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            //loggerFactory.add("Logs/myapp-{Date}.txt"); ??? Add log in DB.

             if (env.IsDevelopment())
             {
                 app.UseDeveloperExceptionPage();
                 app.UseBrowserLink();
             }
             else
             {
                 app.UseExceptionHandler("/Home/Error");
             }
             app.UseStatusCodePages(); //return 500 (Internal Server Error) or 404 (Not Found)
             
            //app.UseStaticFiles();


            /*app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();*/

            app.UseCors("AllowAll");

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DefaultDbInitializer.Initialize(defaultDbContext);
        }        

    }

    public static class DI
    {
        public static IServiceProvider AddDryIoc<TCompositionRoot>(this IServiceCollection services)
        {
            var container = new Container().WithDependencyInjectionAdapter(services);
            container.RegisterMany<TCompositionRoot>();
            container.Resolve<TCompositionRoot>();
            return container.Resolve<IServiceProvider>();
        }
    }
}