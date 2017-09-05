using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using MediatR;
using SchemaManagement.API.Events.Events;
using SchemaManagement.Domain;
using Task = System.Threading.Tasks.Task;

namespace SchemaManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CreateSchemaTaskEventCommand" />
    public class CreateSchemaTaskEventCommandHandler : IAsyncRequestHandler<CreateSchemaTaskEventCommand, Domain.Task>
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
        public async Task<Domain.Task> Handle(CreateSchemaTaskEventCommand message)
        {
            Schema schema = await this._repository.Get(message.SchemaId);
            Domain.Task task = schema.AddTask(message.Name);
            await this._repository.Update(schema);

            this._eventBus.Publish(new TaskCreatedEvent(message.SchemaId, message.Name));

            return task;
        }
    }
}