using System.Collections.Generic;
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
    /// <seealso cref="IEventHandler{TIntegrationEvent}.API.IntegrationEvents.Events.ScenarioCreatedEvent}" />
    public class ScenarioCreatedEventHandler : IEventHandler<ScenarioCreatedEvent>
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
        /// Initializes a new instance of the <see cref="ScenarioCreatedEventHandler" /> class.
        /// </summary>
        /// <param name="scenarioQueryRepository">The scenario query repository.</param>
        /// <param name="procedureQueryRepository">The procedure query repository.</param>
        public ScenarioCreatedEventHandler(IScenarioQueryRepository scenarioQueryRepository, IProcedureQueryRepository procedureQueryRepository)
        {
            this._scenarioQueryRepository = scenarioQueryRepository;
            this._procedureQueryRepository = procedureQueryRepository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioCreatedEvent @event)
        {
            ScenarioQueryDto scenario = new ScenarioQueryDto
            {
                Id = @event.ScenarioId,
                Name = @event.Name
            };

            ProcedureQueryDto procedure = await this._procedureQueryRepository.Get(@event.ProcedureId);
            procedure.Scenarios.Add(scenario);
            await this._procedureQueryRepository.Update(procedure);
            await this._scenarioQueryRepository.Add(scenario);
        }
    }
}