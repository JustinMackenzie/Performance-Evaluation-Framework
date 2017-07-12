using MediatR;
using Schema.Domain;
using Task = System.Threading.Tasks.Task;

namespace Schema.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{Schema.API.Application.Commands.CreateSchemaTaskEventCommand}" />
    public class CreateSchemaTaskEventCommandHandler : IAsyncRequestHandler<CreateSchemaTaskEventCommand>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ISchemaRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSchemaTaskEventCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CreateSchemaTaskEventCommandHandler(ISchemaRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task Handle(CreateSchemaTaskEventCommand message)
        {
            Domain.Schema schema = this._repository.Get(message.SchemaId);
            schema.AddTask(message.Name);
            this._repository.Update(schema);

            return Task.CompletedTask;;
        }
    }
}