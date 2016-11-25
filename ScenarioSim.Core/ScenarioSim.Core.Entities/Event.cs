using System;
using System.Collections.Generic;
using System.Linq;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// The base class for all actions.
    /// </summary>
    public class Event : Entity
    {
        /// <summary>
        /// Gets or sets the scenario performance identifier.
        /// </summary>
        /// <value>
        /// The scenario performance identifier.
        /// </value>
        public Guid ScenarioPerformanceId { get; set; }

        /// <summary>
        /// Gets or sets the scenario performance.
        /// </summary>
        /// <value>
        /// The scenario performance.
        /// </value>
        public virtual ScenarioPerformance ScenarioPerformance { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public Dictionary<string, EventParameter> Parameters => ParameterCollection.ToDictionary(p => p.Name);

        /// <summary>
        /// Gets or sets the parameter collection.
        /// </summary>
        /// <value>
        /// The parameter collection.
        /// </value>
        public virtual ICollection<EventParameter> ParameterCollection { get; set; }

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameter">The parameter.</param>
        public void AddParameter(string name, EventParameter parameter)
        {
            Parameters.Add(name, parameter);
        }
    }
}