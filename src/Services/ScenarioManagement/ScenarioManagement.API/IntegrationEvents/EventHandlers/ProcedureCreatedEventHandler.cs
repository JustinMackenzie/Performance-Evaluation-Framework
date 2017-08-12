using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using ScenarioManagement.API.IntegrationEvents.Events;
using ScenarioManagement.API.Repositories;

namespace ScenarioManagement.API.IntegrationEvents.EventHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IIntegrationEventHandler{ScenarioManagement.API.IntegrationEvents.Events.ProcedureCreatedEvent}" />
    public class ProcedureCreatedEventHandler : IIntegrationEventHandler<ProcedureCreatedEvent>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IProcedureQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcedureCreatedEventHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ProcedureCreatedEventHandler(IProcedureQueryRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ProcedureCreatedEvent @event)
        {
            await this._repository.Add(new ProcedureQueryDto{ Id = @event.ProcedureId, Name = @event.ProcedureName });
        }
    }
}