using System;
using System.Collections.Generic;

namespace ScenarioSim.Core.DataTransfer
{
    /// <summary>
    /// The view model for schema details.
    /// </summary>
    public class Schema
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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
        /// Gets or sets the task transitions.
        /// </summary>
        /// <value>
        /// The task transitions.
        /// </value>
        public List<TaskTransition> TaskTransitions { get; set; }

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public List<Task> Tasks { get; set; }
    }
}