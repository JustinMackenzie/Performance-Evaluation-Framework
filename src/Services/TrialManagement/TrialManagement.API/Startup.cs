using System.IO;
using BuildingBlocks.EventBus.Abstractions;
using EventBus.RawRabbit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RawRabbit.Serialization;
using RawRabbit.vNext;
using TrialManagement.Domain;
using TrialManagement.Infrastructure;

namespace TrialManagement.API
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddMediatR(typeof(Startup));
            services.AddRawRabbit(cfg => cfg.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("rawrabbit.json"),
                ioc => ioc.AddSingleton<IMessageSerializer, TypelessJsonSerializer>());

            services.AddTransient<ITrialRepository, TrialRepository>(provder =>
                new TrialRepository(Configuration.GetConnectionString("TrialDatabase"), "trial-context"));
            services.AddSingleton<IRawRabbitSubscriptionRepository, InMemoryRawRabbitSubscriptionRepository>();
            services.AddTransient<IEventBus, RawRabbitEventBus>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddAzureWebAppDiagnostics();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
