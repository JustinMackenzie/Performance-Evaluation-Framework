using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using MediatR;
using ScenarioManagement.API.IntegrationEvents.Events;
using ScenarioManagement.Domain;
using ScenarioManagement.Domain.Exceptions;

namespace ScenarioManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="RemoveAssetFromScenarioCommand" />
    public class RemoveAssetFromScenarioCommandHandler : IAsyncRequestHandler<RemoveAssetFromScenarioCommand>
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
        /// Initializes a new instance of the <see cref="RemoveAssetFromScenarioCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public RemoveAssetFromScenarioCommandHandler(IProcedureRepository repository, IEventBus eventBus)
        {
            this._repository = repository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        /// <exception cref="ScenarioManagementDomainException">A scenario with the given identifier does not exist.</exception>
        public async Task Handle(RemoveAssetFromScenarioCommand command)
        {
            Procedure procedure = await this._repository.Get(command.ProcedureId);

            if (procedure == null)
            {
                throw new ScenarioManagementDomainException("A procedure with the given identifier does not exist.");
            }

            procedure.RemoveScenarioAsset(command.ScenarioId, command.Tag);
            await this._repository.Update(procedure);
            this._eventBus.Publish(new ScenarioAssetRemovedEvent(procedure.Id, command.ScenarioId, command.Tag));
        }
    }
}