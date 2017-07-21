using System;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;

namespace ConsoleSchemaManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.CommandHandlers.ICommandHandler{ConsoleSchemaManager.Commands.CreateSchemaEventCommand}" />
    public class CreateSchemaEventCommandHandler : ICommandHandler<CreateSchemaEventCommand>
    {
        /// <summary>
        /// The service
        /// </summary>
        private ISchemaService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSchemaEventCommandHandler"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public CreateSchemaEventCommandHandler(ISchemaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public int Handle(CreateSchemaEventCommand command)
        {
            CreateSchemaEventRequest request = new CreateSchemaEventRequest
            {
                Name = command.Name,
                SchemaId = Guid.Parse(command.SchemaId),
                ServerUrl = command.ServerUrl
            };

            try
            {
                var response = this._service.CreateSchemaEvent(request);
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
