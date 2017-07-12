using System;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;

namespace ConsoleSchemaManager.CommandHandlers
{
    public class CreateSchemaTaskCommandHandler : ICommandHandler<CreateSchemaTaskCommand>
    {
        private readonly ISchemaService _service;

        public CreateSchemaTaskCommandHandler(ISchemaService service)
        {
            _service = service;
        }

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
