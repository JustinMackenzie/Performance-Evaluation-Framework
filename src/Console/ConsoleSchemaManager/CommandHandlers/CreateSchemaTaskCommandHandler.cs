using System;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;
using MediatR;

namespace ConsoleSchemaManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{ConsoleSchemaManager.Commands.CreateSchemaTaskCommand, System.Int32}" />
    public class CreateSchemaTaskCommandHandler : IRequestHandler<CreateSchemaTaskCommand, int>
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
                var response = this._service.CreateSchemaTask(request);
                Console.WriteLine(response);
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
