using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Gateway.API.Events.SchemaManagement;
using MediatR;
using SchemaManagement.Domain;

namespace Gateway.API.Command.SchemaManagement
{
    public class CreateSchemaEventCommandHandler : IAsyncRequestHandler<CreateSchemaEventCommand, Event>
    {
        private readonly ISchemaRepository _repository;

        private readonly IEventBus _eventBus;

        public CreateSchemaEventCommandHandler(ISchemaRepository repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public async Task<Event> Handle(CreateSchemaEventCommand message)
        {
            Schema schema = await this._repository.Get(message.SchemaId);
            Event @event = schema.AddEvent(message.Name);
            await this._repository.Update(schema);

            this._eventBus.Publish(new EventCreatedEvent(message.SchemaId, message.Name));

            return @event;
        }
    }
}
