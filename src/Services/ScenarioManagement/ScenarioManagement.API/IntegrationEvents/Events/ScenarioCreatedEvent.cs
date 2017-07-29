using System;
using BuildingBlocks.EventBus.Events;

namespace ScenarioManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class ScenarioCreatedEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioCreatedEvent"/> class.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="name">The name.</param>
        public ScenarioCreatedEvent(Guid scenarioId, string name)
        {
            this.ScenarioId = scenarioId;
            this.Name = name;
        }
    }
}
