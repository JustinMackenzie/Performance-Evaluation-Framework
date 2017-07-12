using MediatR;
using SchemaManagement.Domain;
using Task = System.Threading.Tasks.Task;

namespace SchemaManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{Schema.API.Application.Commands.CreateTaskTransitionCommand}" />
    public class CreateTaskTransitionCommandHandler : IAsyncRequestHandler<CreateTaskTransitionCommand>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ISchemaRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaskTransitionCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CreateTaskTransitionCommandHandler(ISchemaRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task Handle(CreateTaskTransitionCommand message)
        {
            Domain.Schema schema = this._repository.Get(message.SchemaId);
            schema.AddTaskTransition(message.EventName, message.SourceTaskName, message.DestinationTaskName);
            this._repository.Update(schema);

            return Task.CompletedTask;
        }
    }
}
