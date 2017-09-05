using System;
using BuildingBlocks.EventBus.Events;

namespace Gateway.API.Events.TrialSetManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Event" />
    public class ScenarioAddedToTrialSetEvent : Event
    {
        /// <summary>
        /// Gets the trial set identifier.
        /// </summary>
        /// <value>
        /// The trial set identifier.
        /// </value>
        public Guid TrialSetId { get; private set; }

        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAddedToTrialSetEvent"/> class.
        /// </summary>
        /// <param name="trialSetId">The trial set identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        public ScenarioAddedToTrialSetEvent(Guid trialSetId, Guid scenarioId)
        {
            this.TrialSetId = trialSetId;
            this.ScenarioId = scenarioId;
        }
    }
}