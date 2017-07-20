using System;
using BuildingBlocks.EventBus.Events;

namespace TrialSetManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class TrialSetNameChangedIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the trial set identifier.
        /// </summary>
        /// <value>
        /// The trial set identifier.
        /// </value>
        public Guid TrialSetId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSetNameChangedIntegrationEvent"/> class.
        /// </summary>
        /// <param name="trialSetId">The trial set identifier.</param>
        /// <param name="name">The name.</param>
        public TrialSetNameChangedIntegrationEvent(Guid trialSetId, string name)
        {
            this.TrialSetId = trialSetId;
            this.Name = name;
        }
    }
}