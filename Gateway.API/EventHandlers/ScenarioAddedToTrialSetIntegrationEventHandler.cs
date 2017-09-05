using System.Collections.Generic;
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
    /// <seealso cref="ScenarioAddedToTrialSetEvent" />
    public class ScenarioAddedToTrialSetEventHandler 
        : IEventHandler<ScenarioAddedToTrialSetEvent>
    {
        /// <summary>
        /// The scenarioRepository
        /// </summary>
        private readonly IScenarioQueryRepository _scenarioRepository;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly ITrialSetQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAddedToTrialSetEventHandler"/> class.
        /// </summary>
        /// <param name="scenarioRepository">The scenario repository.</param>
        /// <param name="repository">The repository.</param>
        public ScenarioAddedToTrialSetEventHandler(IScenarioQueryRepository scenarioRepository, ITrialSetQueryRepository repository)
        {
            this._scenarioRepository = scenarioRepository;
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
            ScenarioQueryDto scenarioQuery = await this._scenarioRepository.Get(@event.ScenarioId);

            if (trialSetQuery.Scenarios == null)
                trialSetQuery.Scenarios = new List<ScenarioQueryDto>();

            trialSetQuery.Scenarios.Add(scenarioQuery);

            await this._repository.Update(trialSetQuery);
        }
    }
}