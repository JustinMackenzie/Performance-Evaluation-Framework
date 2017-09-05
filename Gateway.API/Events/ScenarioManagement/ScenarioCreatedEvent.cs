using System;
using BuildingBlocks.EventBus.Events;

namespace Gateway.API.Events.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Event" />
    public class ScenarioCreatedEvent : Event
    {
        /// <summary>
        /// Gets or sets the procedure identifier.
        /// </summary>
        /// <value>
        /// The procedure identifier.
        /// </value>
        public Guid ProcedureId { get; set; }

        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioCreatedEvent" /> class.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="name">The name.</param>
        public ScenarioCreatedEvent(Guid procedureId, Guid scenarioId, string name)
        {
            this.ProcedureId = procedureId;
            this.ScenarioId = scenarioId;
            this.Name = name;
        }
    }
}
