using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Gateway.API.Events.SchemaManagement;
using MediatR;
using SchemaManagement.Domain;

namespace Gateway.API.Command.SchemaManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CreateSchemaCommand" />
    public class CreateSchemaCommandHandler : IAsyncRequestHandler<CreateSchemaCommand, Schema>
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
        /// Initializes a new instance of the <see cref="CreateSchemaCommandHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public CreateSchemaCommandHandler(ISchemaRepository repository, IEventBus eventBus)
        {
            this._repository = repository;
            this._eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public Task<Schema> Handle(CreateSchemaCommand command)
        {
            Schema schema = new Schema(command.Name, command.Description);

            this._repository.Add(schema);

            this._eventBus.Publish(new SchemaCreatedEvent(schema.Id, schema.Name, schema.Description));

            return System.Threading.Tasks.Task.FromResult(schema);
        }
    }
}
