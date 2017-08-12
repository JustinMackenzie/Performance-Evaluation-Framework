using System;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using MediatR;
using ScenarioManagement.API.IntegrationEvents.Events;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{ScenarioManagement.API.Application.Commands.RemoveProcedureCommand}" />
    /// <seealso cref="MediatR.IAsyncRequestHandler{ScenarioManagement.API.Controllers.RemoveProcedureCommand}" />
    public class RemoveProcedureCommandHandler : IAsyncRequestHandler<RemoveProcedureCommand>
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
        /// Initializes a new instance of the <see cref="RemoveProcedureCommandHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public RemoveProcedureCommandHandler(IProcedureRepository repository, IEventBus eventBus)
        {
            this._repository = repository;
            this._eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task Handle(RemoveProcedureCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));   
            }

            await this._repository.Delete(command.ProcedureId);
            this._eventBus.Publish(new ProcedureRemovedEvent(command.ProcedureId));
        }
    }
}