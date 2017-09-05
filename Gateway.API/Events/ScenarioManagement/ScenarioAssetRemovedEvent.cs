using System;
using BuildingBlocks.EventBus.Events;

namespace Gateway.API.Events.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Event" />
    public class ScenarioAssetRemovedEvent : Event
    {
        /// <summary>
        /// Gets the procedure identifier.
        /// </summary>
        /// <value>
        /// The procedure identifier.
        /// </value>
        public Guid ProcedureId { get; }

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
        /// Initializes a new instance of the <see cref="ScenarioAssetRemovedEvent" /> class.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="tag">The tag.</param>
        public ScenarioAssetRemovedEvent(Guid procedureId, Guid scenarioId, string tag)
        {
            this.ProcedureId = procedureId;
            this.ScenarioId = scenarioId;
            this.Tag = tag;
        }
    }
}