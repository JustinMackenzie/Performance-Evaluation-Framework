using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using ScenarioManagement.API.Application.Queries;
using ScenarioManagement.API.IntegrationEvents.Events;
using ScenarioManagement.API.Repositories;

namespace ScenarioManagement.API.IntegrationEvents.EventHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IEventHandler{TIntegrationEvent}.API.IntegrationEvents.Events.ScenarioAssetRemovedEvent}" />
    public class ScenarioAssetRemovedEventHandler : IEventHandler<ScenarioAssetRemovedEvent>
    {
        /// <summary>
        /// The scenario query repository
        /// </summary>
        private readonly IScenarioQueryRepository _scenarioQueryRepository;

        /// <summary>
        /// The procedure query repository
        /// </summary>
        private readonly IProcedureQueryRepository _procedureQueryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAssetRemovedEventHandler" /> class.
        /// </summary>
        /// <param name="scenarioQueryRepository">The scenario query repository.</param>
        /// <param name="procedureQueryRepository">The procedure query repository.</param>
        public ScenarioAssetRemovedEventHandler(IScenarioQueryRepository scenarioQueryRepository, IProcedureQueryRepository procedureQueryRepository)
        {
            this._scenarioQueryRepository = scenarioQueryRepository;
            _procedureQueryRepository = procedureQueryRepository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioAssetRemovedEvent @event)
        {
            ProcedureQueryDto procedure = await this._procedureQueryRepository.Get(@event.ProcedureId);
            ScenarioQueryDto scenario = procedure.Scenarios.SingleOrDefault(s => s.Id == @event.ScenarioId);

            ScenarioAssetDto scenarioAsset = scenario?.Assets.SingleOrDefault(a => a.Tag == @event.Tag);

            if (scenarioAsset != null)
            {
                scenario.Assets.Remove(scenarioAsset);
                await this._procedureQueryRepository.Update(procedure);
            }

            scenario = await this._scenarioQueryRepository.Get(@event.ScenarioId);
            ScenarioAssetDto asset = scenario.Assets.SingleOrDefault(a => a.Tag == @event.Tag);

            if (asset != null)
            {
                scenario.Assets.Remove(asset);
                await this._scenarioQueryRepository.Update(scenario);
            }
        }
    }
}