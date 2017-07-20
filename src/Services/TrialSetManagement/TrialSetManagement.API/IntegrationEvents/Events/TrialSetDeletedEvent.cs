using System;
using BuildingBlocks.EventBus.Events;

namespace TrialSetManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class TrialSetDeletedEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets the trial set identifier.
        /// </summary>
        /// <value>
        /// The trial set identifier.
        /// </value>
        public Guid TrialSetId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSetDeletedEvent"/> class.
        /// </summary>
        /// <param name="trialSetId">The trial set identifier.</param>
        public TrialSetDeletedEvent(Guid trialSetId)
        {
            this.TrialSetId = trialSetId;
        }
    }
}