using DAL;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            /*if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            */
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));  // before add MVC

            /*services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling =
                                                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);*/

            services.AddDbContext<DefaultDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DataMiningDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DataMiningConnection")));

            services.AddMvc();

            /*services.AddScoped<IDbContextFactory, DbContextFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(ILoginService), typeof(LoginService));*/
            //services.AddScoped<ILoginService, LoginService>();


            //return services.AddDryIoc<Bootstrap>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory
                                , DefaultDbContext defaultDbContext, DataMiningDbContext dataMiningDbContext)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddConsole();
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