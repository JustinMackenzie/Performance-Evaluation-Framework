using System.Threading.Tasks;
using MediatR;
using SchemaManagement.Domain;
using Task = System.Threading.Tasks.Task;

namespace SchemaManagement.API.Application.Commands
{
    public class CreateSchemaEventCommandHandler : IAsyncRequestHandler<CreateSchemaEventCommand, Event>
    {
        private readonly ISchemaRepository _repository;

        public CreateSchemaEventCommandHandler(ISchemaRepository repository)
        {
            _repository = repository;
        }

        public Task<Event> Handle(CreateSchemaEventCommand message)
        {
            Domain.Schema schema = this._repository.Get(message.SchemaId);
            Event @event = schema.AddEvent(message.Name);
            this._repository.Update(schema);

            return Task.FromResult(@event);
        }
    }
}
