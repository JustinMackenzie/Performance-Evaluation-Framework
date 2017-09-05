using BuildingBlocks.EventBus.Abstractions;
using Gateway.API.EventHandlers;
using Gateway.API.Events.ScenarioManagement;
using Gateway.API.Events.TrialSetManagement;
using Gateway.API.Infrastructure;
using Gateway.API.Query.ScenarioManagement;
using Gateway.API.Query.TrialSetManagement;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScenarioManagement.Domain;
using ScenarioManagement.Infrastructure;
using SchemaManagement.Domain;
using SchemaManagement.Infrastructure;
using TrialManagement.Domain;
using TrialManagement.Infrastructure;
using TrialSetManagement.Domain;
using TrialSetManagement.Infrastructure;
using ScenarioCreatedEvent = Gateway.API.Events.ScenarioManagement.ScenarioCreatedEvent;

namespace Gateway.API
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

            services.AddSingleton<IEventBus, InProcessEventBus>();

            // Command Stack
            services.AddTransient<IProcedureRepository, ProcedureRepository>(provider =>
                new ProcedureRepository(Configuration.GetConnectionString("ScenarioDatabase"), "scenario-context"));
            services.AddTransient<ISchemaRepository, SchemaRepository>(provder =>
                new SchemaRepository(Configuration.GetConnectionString("SchemaDatabase"), "schema-context"));
            services.AddTransient<ITrialRepository, TrialRepository>(provder =>
                new TrialRepository(Configuration.GetConnectionString("TrialDatabase"), "trial-context"));
            services.AddTransient<ITrialSetRepository, TrialSetRepository>(provder =>
                new TrialSetRepository(Configuration.GetConnectionString("TrialSetDatabase"), "trial-set-context"));

            // Query Stack
            services.AddTransient<IProcedureQueries, ProcedureQueries>();
            services.AddTransient<IProcedureQueryRepository, ProcedureQueryRepository>(provider =>
                new ProcedureQueryRepository(Configuration.GetConnectionString("ScenarioDatabase"), "scenario-context"));
            services.AddTransient<IScenarioQueries, ScenarioQueries>();
            services.AddTransient<IScenarioQueryRepository, ScenarioQueryRepository>(provider =>
                new ScenarioQueryRepository(Configuration.GetConnectionString("ScenarioDatabase"), "scenario-context"));
            services.AddTransient<ITrialSetQueries, TrialSetQueries>();
            services.AddTransient<ITrialSetQueryRepository, TrialSetQueryRepository>(provder =>
                new TrialSetQueryRepository(Configuration.GetConnectionString("TrialSetDatabase"), "trial-set-context"));

            // Event Handlers
            services.AddTransient<ScenarioCreatedEventHandler>();
            services.AddTransient<ScenarioAssetAddedEventHandler>();
            services.AddTransient<ScenarioRemovedEventHandler>();
            services.AddTransient<ScenarioAssetRemovedEventHandler>();
            services.AddTransient<ProcedureCreatedEventHandler>();
            services.AddTransient<ProcedureRemovedEventHandler>();
            services.AddTransient<TrialSetCreatedEventHandler>();
            services.AddTransient<ScenarioAddedToTrialSetEventHandler>();
            services.AddTransient<ScenarioRemovedFromTrialSetEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            this.ConfigureEventHandlers(app);
        }

        private void ConfigureEventHandlers(IApplicationBuilder app)
        {
            IEventBus eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<ScenarioCreatedEvent, ScenarioCreatedEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ScenarioCreatedEventHandler>());
            eventBus.Subscribe<ScenarioAssetAddedEvent, ScenarioAssetAddedEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ScenarioAssetAddedEventHandler>());
            eventBus.Subscribe<ScenarioRemovedEvent, ScenarioRemovedEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ScenarioRemovedEventHandler>());
            eventBus.Subscribe<ScenarioAssetRemovedEvent, ScenarioAssetRemovedEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ScenarioAssetRemovedEventHandler>());
            eventBus.Subscribe<ProcedureCreatedEvent, ProcedureCreatedEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ProcedureCreatedEventHandler>());
            eventBus.Subscribe<ProcedureRemovedEvent, ProcedureRemovedEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ProcedureRemovedEventHandler>());

            eventBus.Subscribe<TrialSetCreatedEvent, TrialSetCreatedEventHandler>
                (() => app.ApplicationServices.GetRequiredService<TrialSetCreatedEventHandler>());
            eventBus.Subscribe<ScenarioAddedToTrialSetEvent, ScenarioAddedToTrialSetEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ScenarioAddedToTrialSetEventHandler>());
            eventBus.Subscribe<ScenarioRemovedFromTrialEvent, ScenarioRemovedFromTrialSetEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ScenarioRemovedFromTrialSetEventHandler>());
        }
    }
}
