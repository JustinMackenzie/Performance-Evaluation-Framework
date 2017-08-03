using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using MediatR;
using ScenarioManagement.API.Controllers;
using ScenarioManagement.API.IntegrationEvents.Events;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.Application.Commands
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
        private readonly IScenarioRepository _repository;

        /// <summary>
        /// The event bus
        /// </summary>
        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveScenarioCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public RemoveScenarioCommandHandler(IScenarioRepository repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task Handle(RemoveScenarioCommand message)
        {
            await this._repository.Delete(message.ScenarioId);
            this._eventBus.Publish(new ScenarioRemovedEvent(message.ScenarioId));
        }
    }
}