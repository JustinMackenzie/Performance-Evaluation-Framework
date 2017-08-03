using System;
using BuildingBlocks.EventBus.Events;

namespace ScenarioManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class ScenarioAssetRemovedEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAssetRemovedEvent"/> class.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="tag">The tag.</param>
        public ScenarioAssetRemovedEvent(Guid scenarioId, string tag)
        {
            this.ScenarioId = scenarioId;
            this.Tag = tag;
        }
    }
}