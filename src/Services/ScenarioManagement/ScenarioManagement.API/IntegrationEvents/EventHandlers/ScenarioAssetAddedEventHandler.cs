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
    /// <seealso cref="IEventHandler{TIntegrationEvent}.API.IntegrationEvents.Events.ScenarioAssetAddedEvent}" />
    public class ScenarioAssetAddedEventHandler : IEventHandler<ScenarioAssetAddedEvent>
    {
        /// <summary>
        /// The scenario query repository
        /// </summary>
        private readonly IScenarioQueryRepository _scenarioQueryRepository;

        /// <summary>
        /// The procedure query repository
        /// </summary>
        private IProcedureQueryRepository _procedureQueryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAssetAddedEventHandler" /> class.
        /// </summary>
        /// <param name="scenarioQueryRepository">The scenario query repository.</param>
        public ScenarioAssetAddedEventHandler(IScenarioQueryRepository scenarioQueryRepository, IProcedureQueryRepository procedureQueryRepository)
        {
            this._scenarioQueryRepository = scenarioQueryRepository;
            this._procedureQueryRepository = procedureQueryRepository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioAssetAddedEvent @event)
        {
            ScenarioAssetDto asset = new ScenarioAssetDto
            {
                Tag = @event.Tag,
                Position = @event.Position,
                Rotation = @event.Rotation,
                Scale = @event.Scale
            };

            ProcedureQueryDto procedure = await this._procedureQueryRepository.Get(@event.ProcedureId);
            ScenarioQueryDto scenario = procedure.Scenarios.SingleOrDefault(s => s.Id == @event.ScenarioId);

            scenario?.Assets.Add(asset);
            await this._procedureQueryRepository.Update(procedure);

            scenario = await this._scenarioQueryRepository.Get(@event.ScenarioId);
            scenario?.Assets.Add(asset);
            await this._scenarioQueryRepository.Update(scenario);
        }
    }
}