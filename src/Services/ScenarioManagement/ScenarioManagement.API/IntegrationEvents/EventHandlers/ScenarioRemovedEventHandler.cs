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
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IIntegrationEventHandler{ScenarioManagement.API.IntegrationEvents.Events.ScenarioRemovedEvent}" />
    public class ScenarioRemovedEventHandler : IIntegrationEventHandler<ScenarioRemovedEvent>
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
        /// Initializes a new instance of the <see cref="ScenarioRemovedEventHandler" /> class.
        /// </summary>
        /// <param name="scenarioQueryRepository">The scenario query repository.</param>
        /// <param name="procedureQueryRepository">The procedure query repository.</param>
        public ScenarioRemovedEventHandler(IScenarioQueryRepository scenarioQueryRepository, IProcedureQueryRepository procedureQueryRepository)
        {
            this._scenarioQueryRepository = scenarioQueryRepository;
            this._procedureQueryRepository = procedureQueryRepository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioRemovedEvent @event)
        {
            ProcedureQueryDto procedure = await this._procedureQueryRepository.Get(@event.ProcedureId);
            ScenarioQueryDto scenario = procedure.Scenarios.SingleOrDefault(s => s.Id == @event.ScenarioId);

            if (scenario != null)
            {
                procedure.Scenarios.Remove(scenario);
                await this._procedureQueryRepository.Update(procedure);
            }

            await this._scenarioQueryRepository.Remove(@event.ScenarioId);
        }
    }
}