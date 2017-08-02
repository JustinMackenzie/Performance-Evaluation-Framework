using System;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;
using MediatR;

namespace ConsoleSchemaManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{ConsoleSchemaManager.Commands.CreateTaskTransitionCommand, System.Int32}" />
    public class CreateTaskTransitionCommandHandler : IRequestHandler<CreateTaskTransitionCommand, int>
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly ISchemaService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaskTransitionCommandHandler" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public CreateTaskTransitionCommandHandler(ISchemaService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public int Handle(CreateTaskTransitionCommand command)
        {
            CreateTaskTransitionRequest request = new CreateTaskTransitionRequest
            {
                EventName = command.EventName,
                SchemaId = Guid.Parse(command.SchemaId),
                ServerUrl = command.ServerUrl,
                SourceTaskName = command.SourceTaskName,
                DestinationTaskName = command.DestinationTask
            };

            try
            {
                var response = this._service.CreateTaskTransition(request);
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
