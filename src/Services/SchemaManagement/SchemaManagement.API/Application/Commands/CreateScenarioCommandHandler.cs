using BuildingBlocks.EventBus.Abstractions;
using MediatR;
using SchemaManagement.API.IntegrationEvents.Events;
using SchemaManagement.Domain;
using Task = System.Threading.Tasks.Task;

namespace SchemaManagement.API.Application.Commands
{
    public class CreateScenarioCommandHandler : IAsyncRequestHandler<CreateScenarioCommand>
    {
        private readonly ISchemaRepository _repository;

        private readonly IEventBus _eventBus;

        public CreateScenarioCommandHandler(ISchemaRepository repository, IEventBus eventBus)
        {
            this._repository = repository;
            _eventBus = eventBus;
        }

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