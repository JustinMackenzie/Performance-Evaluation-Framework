using System;
using BuildingBlocks.EventBus.Events;

namespace ScenarioManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Event" />
    public class ScenarioRemovedEvent : Event
    {
        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; }

        /// <summary>
        /// Gets the procedure identifier.
        /// </summary>
        /// <value>
        /// The procedure identifier.
        /// </value>
        public Guid ProcedureId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioRemovedEvent" /> class.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        public ScenarioRemovedEvent(Guid procedureId, Guid scenarioId)
        {
            this.ProcedureId = procedureId;
            this.ScenarioId = scenarioId;
        }
    }
}