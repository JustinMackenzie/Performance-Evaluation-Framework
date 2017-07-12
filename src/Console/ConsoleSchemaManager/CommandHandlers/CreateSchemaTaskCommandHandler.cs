using System;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;

namespace ConsoleSchemaManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.CommandHandlers.ICommandHandler{ConsoleSchemaManager.Commands.CreateSchemaTaskCommand}" />
    public class CreateSchemaTaskCommandHandler : ICommandHandler<CreateSchemaTaskCommand>
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly ISchemaService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSchemaTaskCommandHandler"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public CreateSchemaTaskCommandHandler(ISchemaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public int Handle(CreateSchemaTaskCommand command)
        {
            CreateSchemaTaskRequest request = new CreateSchemaTaskRequest
            {
                Name = command.Name,
                SchemaId = Guid.Parse(command.SchemaId),
                ServerUrl = command.ServerUrl
            };

            try
            {
                this._service.CreateSchemaTask(request);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }
    }
}
