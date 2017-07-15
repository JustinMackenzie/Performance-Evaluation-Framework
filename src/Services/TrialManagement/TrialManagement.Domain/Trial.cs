using System;
using System.Collections.Generic;
using TrialManagement.Domain.SeedWork;

namespace TrialManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TrialManagement.Domain.SeedWork.Entity" />
    /// <seealso cref="TrialManagement.Domain.SeedWork.IAggregateRoot" />
    public class Trial : Entity, IAggregateRoot
    {
        /// <summary>
        /// The events
        /// </summary>
        private List<Event> _events;

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public IReadOnlyList<Event> Events => this._events.AsReadOnly();

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
        /// Initializes a new instance of the <see cref="Trial" /> class.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public Trial(Guid scenarioId, Guid userId, DateTime start, DateTime end)
        {
            this.ScenarioId = scenarioId;
            this.UserId = userId;
            this.Start = start.ToUniversalTime();
            this.End = end.ToUniversalTime();
            this._events = new List<Event>();
        }

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void AddEvent(Event @event)
        {
            this._events.Add(@event);
        }
    }
}
