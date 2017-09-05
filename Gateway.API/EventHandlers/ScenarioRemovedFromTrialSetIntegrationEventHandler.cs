using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Gateway.API.Events.TrialSetManagement;
using Gateway.API.Query.ScenarioManagement;
using Gateway.API.Query.TrialSetManagement;

namespace Gateway.API.EventHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioRemovedFromTrialEvent" />
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