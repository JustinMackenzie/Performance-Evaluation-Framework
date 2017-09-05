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
using TrialSetManagement.API.Application.Queries;
using TrialSetManagement.API.Infrastructure.Services;
using TrialSetManagement.API.Events.EventHandling;
using TrialSetManagement.API.Events.Events;
using TrialSetManagement.API.Repositories;
using TrialSetManagement.Domain;
using TrialSetManagement.Infrastructure;

namespace TrialSetManagement.API
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
            services.AddMediatR();
            services.AddRawRabbit(cfg => cfg.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("rawrabbit.json"),
                ioc => ioc.AddSingleton<IMessageSerializer, TypelessJsonSerializer>());
            
            services.AddTransient<ITrialSetRepository, TrialSetRepository>(provder =>
                new TrialSetRepository(Configuration.GetConnectionString("TrialSetDatabase"), "trial-set-context"));
            services.AddTransient<ITrialSetQueries, TrialSetQueries>();
            services.AddSingleton<IRawRabbitSubscriptionRepository, InMemoryRawRabbitSubscriptionRepository>();
            services.AddSingleton<IEventBus, RawRabbitEventBus>();
            services.AddTransient<ITrialSetQueryRepository, TrialSetQueryRepository>(provder =>
                new TrialSetQueryRepository(Configuration.GetConnectionString("TrialSetDatabase"), "trial-set-context"));
            services.AddTransient<IScenarioManagementService, ScenarioManagementService>(provider =>
                new ScenarioManagementService("http://scenariosim-scenario-management.azurewebsites.net"));
            services.AddTransient<TrialSetCreatedEventHandler>();
            services.AddTransient<ScenarioAddedToTrialSetEventHandler>();
            services.AddTransient<ScenarioRemovedFromTrialSetEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddAzureWebAppDiagnostics();

            app.UseMvc();
            this.ConfigureEventBus(app);
        }

        protected void ConfigureEventBus(IApplicationBuilder app)
        {
            IEventBus eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<TrialSetCreatedEvent, TrialSetCreatedEventHandler>
                (() => app.ApplicationServices.GetRequiredService<TrialSetCreatedEventHandler>());
            eventBus.Subscribe<ScenarioAddedToTrialSetEvent, ScenarioAddedToTrialSetEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ScenarioAddedToTrialSetEventHandler>());
            eventBus.Subscribe<ScenarioRemovedFromTrialEvent, ScenarioRemovedFromTrialSetEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ScenarioRemovedFromTrialSetEventHandler>());
        }
    }
}
