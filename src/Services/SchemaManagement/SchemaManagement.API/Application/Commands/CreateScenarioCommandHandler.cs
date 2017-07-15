using BuildingBlocks.EventBus.Abstractions;
using MediatR;
using SchemaManagement.API.IntegrationEvents.Events;
using SchemaManagement.Domain;
using Task = System.Threading.Tasks.Task;

namespace SchemaManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{SchemaManagement.API.Application.Commands.CreateScenarioCommand}" />
    public class CreateScenarioCommandHandler : IAsyncRequestHandler<CreateScenarioCommand>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ISchemaRepository _repository;

        /// <summary>
        /// The event bus
        /// </summary>
        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateScenarioCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public CreateScenarioCommandHandler(ISchemaRepository repository, IEventBus eventBus)
        {
            this._repository = repository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task Handle(CreateScenarioCommand message)
        {
            Schema schema = this._repository.Get(message.SchemaId);
            Scenario scenario = schema.AddScenario(message.Name);
            this._repository.Update(schema);

            this._eventBus.Publish(new ScenarioCreatedIntegrationEvent(scenario.Id, schema.Id, scenario.Name));

            return Task.CompletedTask;
        }
    }
}