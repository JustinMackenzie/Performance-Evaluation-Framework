using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using TrialSetManagement.API.Application.Queries;
using TrialSetManagement.API.Infrastructure.Services;
using TrialSetManagement.API.Events.Events;
using TrialSetManagement.API.Repositories;

namespace TrialSetManagement.API.Events.EventHandling
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IEventHandler{TrialSetManagement.API.Events.Events.ScenarioAddedToTrialSetEvent}" />
    public class ScenarioAddedToTrialSetEventHandler 
        : IEventHandler<ScenarioAddedToTrialSetEvent>
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
        /// Initializes a new instance of the <see cref="ScenarioAddedToTrialSetEventHandler"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="repository">The repository.</param>
        public ScenarioAddedToTrialSetEventHandler(IScenarioManagementService service, ITrialSetQueryRepository repository)
        {
            this._service = service;
            _repository = repository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioAddedToTrialSetEvent @event)
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