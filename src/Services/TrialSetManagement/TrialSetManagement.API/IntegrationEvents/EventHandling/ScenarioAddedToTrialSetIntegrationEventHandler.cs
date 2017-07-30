using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using TrialSetManagement.API.Application.Queries;
using TrialSetManagement.API.Infrastructure.Services;
using TrialSetManagement.API.IntegrationEvents.Events;
using TrialSetManagement.API.Repositories;

namespace TrialSetManagement.API.IntegrationEvents.EventHandling
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IIntegrationEventHandler{TrialSetManagement.API.IntegrationEvents.Events.ScenarioAddedToTrialSetIntegrationEvent}" />
    public class ScenarioAddedToTrialSetIntegrationEventHandler 
        : IIntegrationEventHandler<ScenarioAddedToTrialSetIntegrationEvent>
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IScenarioManagementService _service;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly ITrialSetQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAddedToTrialSetIntegrationEventHandler"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="repository">The repository.</param>
        public ScenarioAddedToTrialSetIntegrationEventHandler(IScenarioManagementService service, ITrialSetQueryRepository repository)
        {
            this._service = service;
            _repository = repository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioAddedToTrialSetIntegrationEvent @event)
        {
            TrialSetQueryDto trialSetQuery = await this._repository.GetTrialSet(@event.TrialSetId);
            ScenarioQueryDto scenarioQuery = await this._service.GetScenario(@event.ScenarioId);

            if (trialSetQuery.Scenarios == null)
                trialSetQuery.Scenarios = new List<ScenarioQueryDto>();

            trialSetQuery.Scenarios.Add(scenarioQuery);

            await this._repository.Update(trialSetQuery);
        }
    }
}