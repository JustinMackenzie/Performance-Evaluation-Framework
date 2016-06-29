﻿namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents an event that arises during a scenario that causes complications and increases
    /// difficulty of the task.
    /// </summary>
    public abstract class ScenarioEvent : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
