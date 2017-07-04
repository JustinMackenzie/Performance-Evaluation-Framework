using System;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;

namespace ConsoleSchemaManager.CommandHandlers
{
    public class CreateSchemaCommandHandler : ICommandHandler<CreateSchemaCommand>
    {
        private readonly ISchemaService _schemaService;

        public CreateSchemaCommandHandler(ISchemaService schemaService)
        {
            this._schemaService = schemaService;
        }

        public int Handle(CreateSchemaCommand command)
        {
            CreateSchemaRequest request = new CreateSchemaRequest
            {
                Name = command.Name,
                Description = command.Description,
                ServerUrl = command.ServerUrl
            };

            try
            {
                this._schemaService.CreateSchema(request);
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 1;
            }
        }
    }
}