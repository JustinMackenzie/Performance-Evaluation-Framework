using System;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Gateway.API.Events.ScenarioManagement;
using MediatR;
using ScenarioManagement.Domain;

namespace Gateway.API.Command.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Procedure" />
    public class CreateProcedureCommandHandler : IAsyncRequestHandler<CreateProcedureCommand, Procedure>
    {
        /// <summary>
        /// The procedure repository
        /// </summary>
        private readonly IProcedureRepository _procedureRepository;

        /// <summary>
        /// The event bus
        /// </summary>
        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProcedureCommandHandler" /> class.
        /// </summary>
        /// <param name="procedureRepository">The procedure repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public CreateProcedureCommandHandler(IProcedureRepository procedureRepository, IEventBus eventBus)
        {
            this._procedureRepository = procedureRepository;
            this._eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task<Procedure> Handle(CreateProcedureCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (string.IsNullOrEmpty(command.Name))
            {
                throw new ArgumentException("The procedure name cannot be null or empty.", nameof(command));
            }

            Procedure procedure = new Procedure(command.Name);
            await this._procedureRepository.Add(procedure);
            this._eventBus.Publish(new ProcedureCreatedEvent(procedure.Id, procedure.Name));

            return procedure;
        }
    }
}