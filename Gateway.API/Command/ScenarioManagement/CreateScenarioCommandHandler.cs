using System;
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
    /// <seealso cref="CreateScenarioCommand" />
    public class CreateScenarioCommandHandler : IAsyncRequestHandler<CreateScenarioCommand, Scenario>
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
        /// Initializes a new instance of the <see cref="CreateScenarioCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public CreateScenarioCommandHandler(IProcedureRepository repository, IEventBus eventBus)
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

            Procedure procedure = await this._repository.Get(command.ProcedureId);
            Scenario scenario = procedure.AddScenario(command.Name);
            await this._repository.Update(procedure);

            this._eventBus.Publish(new ScenarioCreatedEvent(procedure.Id, scenario.Id, scenario.Name));

            return scenario;
        }
    }
}