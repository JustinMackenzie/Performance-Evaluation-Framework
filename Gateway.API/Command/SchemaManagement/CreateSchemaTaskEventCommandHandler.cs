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
    /// <seealso cref="CreateSchemaTaskEventCommand" />
    public class CreateSchemaTaskEventCommandHandler : IAsyncRequestHandler<CreateSchemaTaskEventCommand, global::SchemaManagement.Domain.Task>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ISchemaRepository _repository;

        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSchemaTaskEventCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CreateSchemaTaskEventCommandHandler(ISchemaRepository repository, IEventBus eventBus)
        {
            this._repository = repository;
            this._eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<global::SchemaManagement.Domain.Task> Handle(CreateSchemaTaskEventCommand message)
        {
            Schema schema = await this._repository.Get(message.SchemaId);
            global::SchemaManagement.Domain.Task task = schema.AddTask(message.Name);
            await this._repository.Update(schema);

            this._eventBus.Publish(new TaskCreatedEvent(message.SchemaId, message.Name));

            return task;
        }
    }
}