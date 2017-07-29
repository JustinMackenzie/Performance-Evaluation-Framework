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
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IIntegrationEventHandler{ScenarioManagement.API.IntegrationEvents.Events.ScenarioCreatedEvent}" />
    public class ScenarioCreatedEventHandler : IIntegrationEventHandler<ScenarioCreatedEvent>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IScenarioQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioCreatedEventHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ScenarioCreatedEventHandler(IScenarioQueryRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioCreatedEvent @event)
        {
            ScenarioDto scenario = new ScenarioDto
            {
                Id = @event.ScenarioId,
                Name = @event.Name,
                Assets = new List<ScenarioAssetDto>()
            };

            await this._repository.Add(scenario);
        }
    }
}