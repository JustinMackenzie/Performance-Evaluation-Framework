using System;
using BuildingBlocks.EventBus.Events;

namespace Gateway.API.Events.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Event" />
    public class ProcedureRemovedEvent : Event
    {
        /// <summary>
        /// Gets the procedure identifier.
        /// </summary>
        /// <value>
        /// The procedure identifier.
        /// </value>
        public Guid ProcedureId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcedureRemovedEvent"/> class.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        public ProcedureRemovedEvent(Guid procedureId)
        {
            ProcedureId = procedureId;
        }
    }
}