using System;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;
using MediatR;

namespace ConsoleSchemaManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{ConsoleSchemaManager.Commands.CreateSchemaCommand, System.Int32}" />
    public class CreateSchemaCommandHandler : IRequestHandler<CreateSchemaCommand, int>
    {
        /// <summary>
        /// The schema service
        /// </summary>
        private readonly ISchemaService _schemaService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSchemaCommandHandler"/> class.
        /// </summary>
        /// <param name="schemaService">The schema service.</param>
        public CreateSchemaCommandHandler(ISchemaService schemaService)
        {
            this._schemaService = schemaService;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
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
                var response = this._schemaService.CreateSchema(request);
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