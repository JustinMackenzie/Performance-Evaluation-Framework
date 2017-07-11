using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;

namespace ConsoleSchemaManager.CommandHandlers
{
    public class CreateSchemaEventCommandHandler : ICommandHandler<CreateSchemaEventCommand>
    {
        private ISchemaService _service;

        public CreateSchemaEventCommandHandler(ISchemaService service)
        {
            _service = service;
        }

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
                this._service.CreateSchemaEvent(request);
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
