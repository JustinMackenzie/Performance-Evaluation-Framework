using System;
using BuildingBlocks.EventBus.Events;

namespace TrialSetManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class ScenarioRemovedFromTrialIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; private set; }

        /// <summary>
        /// Gets the trial set identifier.
        /// </summary>
        /// <value>
        /// The trial set identifier.
        /// </value>
        public Guid TrialSetId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioRemovedFromTrialIntegrationEvent"/> class.
        /// </summary>
        /// <param name="trialSetId">The trial set identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        public ScenarioRemovedFromTrialIntegrationEvent(Guid trialSetId, Guid scenarioId)
        {
            this.TrialSetId = trialSetId;
            this.ScenarioId = scenarioId;
        }
    }
}