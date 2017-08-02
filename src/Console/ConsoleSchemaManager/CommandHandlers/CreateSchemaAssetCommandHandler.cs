using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;
using MediatR;

namespace ConsoleSchemaManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{ConsoleSchemaManager.Commands.CreateSchemaAssetCommand, System.Int32}" />
    public class CreateSchemaAssetCommandHandler : IRequestHandler<CreateSchemaAssetCommand, int>
    {
        /// <summary>
        /// The schema service
        /// </summary>
        private readonly ISchemaService _schemaService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSchemaAssetCommandHandler"/> class.
        /// </summary>
        /// <param name="schemaService">The schema service.</param>
        public CreateSchemaAssetCommandHandler(ISchemaService schemaService)
        {
            this._schemaService = schemaService;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
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
                var response = this._schemaService.CreateSchemaAsset(request);
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
