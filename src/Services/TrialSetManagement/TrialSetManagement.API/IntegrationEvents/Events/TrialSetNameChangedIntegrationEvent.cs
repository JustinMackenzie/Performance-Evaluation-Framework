using System;
using BuildingBlocks.EventBus.Events;

namespace TrialSetManagement.API.Events.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.Event" />
    public class TrialSetNameChangedEvent : Event
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
        /// Initializes a new instance of the <see cref="TrialSetNameChangedEvent"/> class.
        /// </summary>
        /// <param name="trialSetId">The trial set identifier.</param>
        /// <param name="name">The name.</param>
        public TrialSetNameChangedEvent(Guid trialSetId, string name)
        {
            this.TrialSetId = trialSetId;
            this.Name = name;
        }
    }
}