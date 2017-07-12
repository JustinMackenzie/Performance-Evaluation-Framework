using System;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;

namespace ConsoleSchemaManager.CommandHandlers
{
    public class CreateScenarioCommandHandler : ICommandHandler<CreateScenarioCommand>
    {
        private ISchemaService _schemaService;

        public CreateScenarioCommandHandler(ISchemaService schemaService)
        {
            this._schemaService = schemaService;
        }

        public int Handle(CreateScenarioCommand command)
        {
            CreateScenarioRequest request = new CreateScenarioRequest
            {
                Name = command.Name,
                SchemaId = Guid.Parse(command.SchemaId),
                ServerUrl = command.ServerUrl
            };

            try
            {
                this._schemaService.CreateScenario(request);
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
