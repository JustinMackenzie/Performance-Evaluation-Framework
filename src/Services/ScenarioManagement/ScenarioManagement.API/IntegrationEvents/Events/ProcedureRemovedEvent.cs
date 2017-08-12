using System;
using BuildingBlocks.EventBus.Events;

namespace ScenarioManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class ProcedureRemovedEvent : IntegrationEvent
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