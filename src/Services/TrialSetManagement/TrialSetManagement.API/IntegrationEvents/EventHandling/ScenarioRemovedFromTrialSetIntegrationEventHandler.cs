using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using TrialSetManagement.API.Application.Queries;
using TrialSetManagement.API.Events.Events;
using TrialSetManagement.API.Repositories;

namespace TrialSetManagement.API.Events.EventHandling
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IEventHandler{TrialSetManagement.API.Events.Events.ScenarioRemovedFromTrialEvent}" />
    public class ScenarioRemovedFromTrialSetEventHandler
        : IEventHandler<ScenarioRemovedFromTrialEvent>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ITrialSetQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioRemovedFromTrialSetEventHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ScenarioRemovedFromTrialSetEventHandler(ITrialSetQueryRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioRemovedFromTrialEvent @event)
        {
            TrialSetQueryDto trialSetQuery = await this._repository.GetTrialSet(@event.TrialSetId);

            ScenarioQueryDto scenarioQuery = trialSetQuery.Scenarios.FirstOrDefault(s => s.Id == @event.ScenarioId);
            trialSetQuery.Scenarios.Remove(scenarioQuery);

            await this._repository.Update(trialSetQuery);
        }
    }
}