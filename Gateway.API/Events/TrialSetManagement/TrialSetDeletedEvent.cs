using System;
using BuildingBlocks.EventBus.Events;

namespace Gateway.API.Events.TrialSetManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Event" />
    public class TrialSetDeletedEvent : Event
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