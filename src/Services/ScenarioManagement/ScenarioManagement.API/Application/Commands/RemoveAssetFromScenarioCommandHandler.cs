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
        private readonly IScenarioRepository _repository;

        /// <summary>
        /// The event bus
        /// </summary>
        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveAssetFromScenarioCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public RemoveAssetFromScenarioCommandHandler(IScenarioRepository repository, IEventBus eventBus)
        {
            this._repository = repository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ScenarioManagementDomainException">A scenario with the given identifier does not exist.</exception>
        public async Task Handle(RemoveAssetFromScenarioCommand message)
        {
            Scenario scenario = await this._repository.Get(message.ScenarioId);

            if (scenario == null)
            {
                throw new ScenarioManagementDomainException("A scenario with the given identifier does not exist.");
            }

            scenario.RemoveAsset(message.Tag);
            this._eventBus.Publish(new ScenarioAssetRemovedEvent(scenario.Id, message.Tag));

            await this._repository.Update(scenario);
        }
    }
}