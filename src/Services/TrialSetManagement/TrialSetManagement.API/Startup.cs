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
using TrialSetManagement.API.IntegrationEvents.EventHandling;
using TrialSetManagement.API.IntegrationEvents.Events;
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
                new TrialSetRepository(Configuration.GetConnectionString("ScenarioDatabase"), "scenario-context"));
            services.AddTransient<ITrialSetQueries, TrialSetQueries>();
            services.AddSingleton<IRawRabbitSubscriptionRepository, InMemoryRawRabbitSubscriptionRepository>();
            services.AddSingleton<IEventBus, RawRabbitEventBus>();
            services.AddTransient<ITrialSetQueryRepository, TrialSetQueryRepository>();
            services.AddTransient<IScenarioManagementService, ScenarioManagementService>();
            services.AddTransient<TrialSetCreatedIntegrationEventHandler>();
            services.AddTransient<ScenarioAddedToTrialSetIntegrationEventHandler>();
            services.AddTransient<ScenarioRemovedFromTrialSetIntegrationEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            this.ConfigureEventBus(app);
        }

        protected void ConfigureEventBus(IApplicationBuilder app)
        {
            IEventBus eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<TrialSetCreatedIntegrationEvent, TrialSetCreatedIntegrationEventHandler>
                (() => app.ApplicationServices.GetRequiredService<TrialSetCreatedIntegrationEventHandler>());
            eventBus.Subscribe<ScenarioAddedToTrialSetIntegrationEvent, ScenarioAddedToTrialSetIntegrationEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ScenarioAddedToTrialSetIntegrationEventHandler>());
            eventBus.Subscribe<ScenarioRemovedFromTrialIntegrationEvent, ScenarioRemovedFromTrialSetIntegrationEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ScenarioRemovedFromTrialSetIntegrationEventHandler>());
        }
    }
}
