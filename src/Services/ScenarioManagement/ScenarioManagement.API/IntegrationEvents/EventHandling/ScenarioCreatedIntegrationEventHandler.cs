using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using ScenarioManagement.API.IntegrationEvents.Events;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.IntegrationEvents.EventHandling
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IIntegrationEventHandler{ScenarioManagement.API.IntegrationEvents.Events.ScenarioCreatedIntegrationEvent}" />
    public class ScenarioCreatedIntegrationEventHandler : IIntegrationEventHandler<ScenarioCreatedIntegrationEvent>
    {
        /// <summary>
        /// The scenario repository
        /// </summary>
        private readonly IScenarioRepository _scenarioRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioCreatedIntegrationEventHandler"/> class.
        /// </summary>
        /// <param name="scenarioRepository">The scenario repository.</param>
        public ScenarioCreatedIntegrationEventHandler(IScenarioRepository scenarioRepository)
        {
            this._scenarioRepository = scenarioRepository;
        }

        /// <summary>
        /// Handles the specified @event.
        /// </summary>
        /// <param name="event">The @event.</param>
        /// <returns></returns>
        public Task Handle(ScenarioCreatedIntegrationEvent @event)
        {
            Scenario scenario = new Scenario(@event.Name);
            this._scenarioRepository.Add(scenario);

            return Task.CompletedTask;
        }
    }
}
