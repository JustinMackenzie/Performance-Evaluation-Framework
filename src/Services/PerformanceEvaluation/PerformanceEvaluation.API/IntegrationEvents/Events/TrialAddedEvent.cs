using System;
using System.Collections.Generic;
using BuildingBlocks.EventBus.Events;

namespace PerformanceEvaluation.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Event" />
    public class TrialAddedEvent : Event
    {
        /// <summary>
        /// Gets or sets the trial identifier.
        /// </summary>
        /// <value>
        /// The trial identifier.
        /// </value>
        public Guid TrialId { get; set; }
        
        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; set; }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public DateTime End { get; set; }

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public IEnumerable<EventDto> Events { get; set; }
    }
}
