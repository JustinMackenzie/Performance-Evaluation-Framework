using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using TrialSetManagement.API.Application.Queries;
using TrialSetManagement.API.IntegrationEvents.Events;
using TrialSetManagement.API.Repositories;

namespace TrialSetManagement.API.IntegrationEvents.EventHandling
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IIntegrationEventHandler{TrialSetManagement.API.IntegrationEvents.Events.ScenarioRemovedFromTrialIntegrationEvent}" />
    public class ScenarioRemovedFromTrialSetIntegrationEventHandler
        : IIntegrationEventHandler<ScenarioRemovedFromTrialIntegrationEvent>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ITrialSetQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioRemovedFromTrialSetIntegrationEventHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ScenarioRemovedFromTrialSetIntegrationEventHandler(ITrialSetQueryRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioRemovedFromTrialIntegrationEvent @event)
        {
            TrialSetQueryDto trialSetQuery = await this._repository.GetTrialSet(@event.TrialSetId);

            ScenarioQueryDto scenarioQuery = trialSetQuery.Scenarios.FirstOrDefault(s => s.Id == @event.ScenarioId);
            trialSetQuery.Scenarios.Remove(scenarioQuery);

            await this._repository.Update(trialSetQuery);
        }
    }
}