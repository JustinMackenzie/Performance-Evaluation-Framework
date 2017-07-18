﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
using ScenarioManagement.API.Application.Queries;
using ScenarioManagement.API.IntegrationEvents.EventHandling;
using ScenarioManagement.API.IntegrationEvents.Events;
using ScenarioManagement.Domain;
using ScenarioManagement.Infrastructure;

namespace ScenarioManagement.API
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

            services.AddTransient<IScenarioRepository, ScenarioRepository>(provder =>
                new ScenarioRepository(Configuration.GetConnectionString("ScenarioDatabase"), "scenario-context"));
            services.AddTransient<ITrialSetRepository, TrialSetRepository>(provder =>
                new TrialSetRepository(Configuration.GetConnectionString("ScenarioDatabase"), "scenario-context"));
            services.AddTransient<ITrialSetQueries, TrialSetQueries>();
            services.AddSingleton<IRawRabbitSubscriptionRepository, InMemoryRawRabbitSubscriptionRepository>();
            services.AddSingleton<IEventBus, RawRabbitEventBus>();
            services.AddTransient<ScenarioCreatedIntegrationEventHandler>();
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

            eventBus.Subscribe<ScenarioCreatedIntegrationEvent, ScenarioCreatedIntegrationEventHandler>
                (() => app.ApplicationServices.GetRequiredService<ScenarioCreatedIntegrationEventHandler>());
        }
    }
}
