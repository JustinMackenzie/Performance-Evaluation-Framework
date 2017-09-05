using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Gateway.API.Events.ScenarioManagement;
using MediatR;
using ScenarioManagement.Domain;

namespace Gateway.API.Command.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{ScenarioManagement.API.Controllers.RemoveScenarioCommand}" />
    public class RemoveScenarioCommandHandler : IAsyncRequestHandler<RemoveScenarioCommand>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IProcedureRepository _repository;

        /// <summary>
        /// The event bus
        /// </summary>
        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveScenarioCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public RemoveScenarioCommandHandler(IProcedureRepository repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task Handle(RemoveScenarioCommand command)
        {
            Procedure procedure = await this._repository.Get(command.ProcedureId);
            procedure.RemoveScenario(command.ScenarioId);
            await this._repository.Update(procedure);
            this._eventBus.Publish(new ScenarioRemovedEvent(command.ProcedureId, command.ScenarioId));
        }
    }
}