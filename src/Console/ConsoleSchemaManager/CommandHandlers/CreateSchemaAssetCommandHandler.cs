using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;

namespace ConsoleSchemaManager.CommandHandlers
{
    public class CreateSchemaAssetCommandHandler : ICommandHandler<CreateSchemaAssetCommand>
    {
        private ISchemaService schemaService;

        public CreateSchemaAssetCommandHandler(ISchemaService schemaService)
        {
            this.schemaService = schemaService;
        }

        public int Handle(CreateSchemaAssetCommand command)
        {
            CreateSchemaAssetRequest request = new CreateSchemaAssetRequest
            {
                Name = command.Name,
                SchemaId = Guid.Parse(command.SchemaId),
                ServerUrl = command.ServerUrl,
                Tag = command.Tag
            };

            try
            {
                var response = this.schemaService.CreateSchemaAsset(request);
                Console.WriteLine(response);
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
