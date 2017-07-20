using System;
using BuildingBlocks.EventBus.Events;

namespace TrialSetManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class TrialSetCreatedIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets the trial set identifier.
        /// </summary>
        /// <value>
        /// The trial set identifier.
        /// </value>
        public Guid TrialSetId { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSetCreatedIntegrationEvent"/> class.
        /// </summary>
        /// <param name="trialSetId">The trial set identifier.</param>
        /// <param name="name">The name.</param>
        public TrialSetCreatedIntegrationEvent(Guid trialSetId, string name)
        {
            this.TrialSetId = trialSetId;
            this.Name = name;
        }
    }
}