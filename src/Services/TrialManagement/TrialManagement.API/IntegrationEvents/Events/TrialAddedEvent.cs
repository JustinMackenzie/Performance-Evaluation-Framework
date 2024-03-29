﻿using System;
using System.Collections.Generic;
using BuildingBlocks.EventBus.Events;
using TrialManagement.API.Application.Commands;

namespace TrialManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.Event" />
    public class TrialAddedEvent : Event
    {
        /// <summary>
        /// Gets or sets the trial identifier.
        /// </summary>
        /// <value>
        /// The trial identifier.
        /// </value>
        public Guid TrialId { get; private set; }
        
        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; private set; }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Gets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public DateTime Start { get; private set; }

        /// <summary>
        /// Gets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public DateTime End { get; private set; }

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public IEnumerable<EventDto> Events { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialAddedEvent" /> class.
        /// </summary>
        /// <param name="trialId">The trial identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="events">The events.</param>
        public TrialAddedEvent(
            Guid trialId, 
            Guid scenarioId, 
            Guid userId, 
            DateTime start, 
            DateTime end, 
            IEnumerable<EventDto> events)
        {
            this.TrialId = trialId;
            this.ScenarioId = scenarioId;
            this.UserId = userId;
            this.Start = start;
            this.End = end;
            this.Events = events;
        }
    }
}
