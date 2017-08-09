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
    /// <seealso cref="CreateScenarioCommand" />
    public class CreateScenarioCommandHandler : IAsyncRequestHandler<CreateScenarioCommand, Scenario>
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
        /// Initializes a new instance of the <see cref="CreateScenarioCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public CreateScenarioCommandHandler(IScenarioRepository repository, IEventBus eventBus)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this._eventBus = eventBus ?? throw  new ArgumentNullException(nameof(eventBus));
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task<Scenario> Handle(CreateScenarioCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            Scenario scenario = new Scenario(command.Name);
            await this._repository.Add(scenario);

            this._eventBus.Publish(new ScenarioCreatedEvent(scenario.Id, scenario.Name));

            return scenario;
        }
    }
}