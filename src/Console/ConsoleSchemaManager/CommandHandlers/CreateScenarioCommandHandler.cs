using System;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;

namespace ConsoleSchemaManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.CommandHandlers.ICommandHandler{ConsoleSchemaManager.Commands.CreateScenarioCommand}" />
    public class CreateScenarioCommandHandler : ICommandHandler<CreateScenarioCommand>
    {
        /// <summary>
        /// The schema service
        /// </summary>
        private readonly ISchemaService _schemaService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateScenarioCommandHandler"/> class.
        /// </summary>
        /// <param name="schemaService">The schema service.</param>
        public CreateScenarioCommandHandler(ISchemaService schemaService)
        {
            this._schemaService = schemaService;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
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
                var response = this._schemaService.CreateScenario(request);
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
