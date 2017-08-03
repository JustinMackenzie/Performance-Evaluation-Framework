using System;
using BuildingBlocks.EventBus.Events;

namespace ScenarioManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class ScenarioRemovedEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioRemovedEvent"/> class.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        public ScenarioRemovedEvent(Guid scenarioId)
        {
            this.ScenarioId = scenarioId;
        }
    }
}