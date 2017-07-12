using MediatR;
using SchemaManagement.Domain;
using Task = System.Threading.Tasks.Task;

namespace SchemaManagement.API.Application.Commands
{
    public class CreateScenarioCommandHandler : IAsyncRequestHandler<CreateScenarioCommand>
    {
        private readonly ISchemaRepository _repository;

        public CreateScenarioCommandHandler(ISchemaRepository repository)
        {
            this._repository = repository;
        }

        public Task Handle(CreateScenarioCommand message)
        {
            Domain.Schema schema = this._repository.Get(message.SchemaId);
            schema.AddScenario(message.Name);
            this._repository.Update(schema);

            return Task.CompletedTask;
        }
    }
}