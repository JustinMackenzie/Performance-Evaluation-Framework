using System;
using BuildingBlocks.EventBus.Events;

namespace Gateway.API.Events.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Event" />
    public class ProcedureCreatedEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcedureCreatedEvent" /> class.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <param name="procedureName">Name of the procedure.</param>
        public ProcedureCreatedEvent(Guid procedureId, string procedureName)
        {
            this.ProcedureId = procedureId;
            this.ProcedureName = procedureName;
        }

        /// <summary>
        /// Gets the name of the procedure.
        /// </summary>
        /// <value>
        /// The name of the procedure.
        /// </value>
        public string ProcedureName { get; }

        /// <summary>
        /// Gets the procedure identifier.
        /// </summary>
        /// <value>
        /// The procedure identifier.
        /// </value>
        public Guid ProcedureId { get; }
    }
}