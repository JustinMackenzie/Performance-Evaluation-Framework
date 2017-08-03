using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
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
        /// The repository
        /// </summary>
        private readonly IScenarioQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioRemovedEventHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ScenarioRemovedEventHandler(IScenarioQueryRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioRemovedEvent @event)
        {
            await this._repository.Remove(@event.ScenarioId);
        }
    }
}