using System;
using MediatR;

namespace ScenarioManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest" />
    public class RemoveProcedureCommand : IRequest
    {
        /// <summary>
        /// Gets the procedure identifier.
        /// </summary>
        /// <value>
        /// The procedure identifier.
        /// </value>
        public Guid ProcedureId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveProcedureCommand"/> class.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        public RemoveProcedureCommand(Guid procedureId)
        {
            this.ProcedureId = procedureId;
        }
    }
}