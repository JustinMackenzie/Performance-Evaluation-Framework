using System.Threading.Tasks;
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
    /// <seealso cref="MediatR.IAsyncRequestHandler{SchemaManagement.API.Application.Commands.CreateTaskTransitionCommand, SchemaManagement.Domain.TaskTransition}" />
    /// <seealso cref="CreateTaskTransitionCommand" />
    public class CreateTaskTransitionCommandHandler : IAsyncRequestHandler<CreateTaskTransitionCommand, TaskTransition>
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
        /// Initializes a new instance of the <see cref="CreateTaskTransitionCommandHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public CreateTaskTransitionCommandHandler(ISchemaRepository repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task<TaskTransition> Handle(CreateTaskTransitionCommand message)
        {
            Schema schema = this._repository.Get(message.SchemaId);
            TaskTransition taskTransition = schema.AddTaskTransition(message.EventName, message.SourceTaskName, message.DestinationTaskName);
            this._repository.Update(schema);

            this._eventBus.Publish(new TaskTransitionCreatedIntegrationEvent(message.SchemaId, message.SourceTaskName, 
                message.DestinationTaskName, message.EventName));

            return Task.FromResult(taskTransition);
        }
    }
}
