using MediatR;
using Schema.Domain;

namespace Schema.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{Schema.API.Application.Commands.CreateSchemaCommand}" />
    public class CreateSchemaCommandHandler : IAsyncRequestHandler<CreateSchemaCommand>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ISchemaRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSchemaCommandHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CreateSchemaCommandHandler(ISchemaRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        System.Threading.Tasks.Task IAsyncRequestHandler<CreateSchemaCommand>.Handle(CreateSchemaCommand message)
        {
            Domain.Schema schema = new Domain.Schema(message.Name, message.Description);
            this._repository.Add(schema);
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
