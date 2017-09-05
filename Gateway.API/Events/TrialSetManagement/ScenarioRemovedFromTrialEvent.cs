using System;
using BuildingBlocks.EventBus.Events;

namespace Gateway.API.Events.TrialSetManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Event" />
    public class ScenarioRemovedFromTrialEvent : Event
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
        /// Initializes a new instance of the <see cref="ScenarioRemovedFromTrialEvent"/> class.
        /// </summary>
        /// <param name="trialSetId">The trial set identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        public ScenarioRemovedFromTrialEvent(Guid trialSetId, Guid scenarioId)
        {
            this.TrialSetId = trialSetId;
            this.ScenarioId = scenarioId;
        }
    }
}