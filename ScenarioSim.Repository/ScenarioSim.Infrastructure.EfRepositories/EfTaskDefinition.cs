﻿using System;
using System.Collections.Generic;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// Represents a task definition.
    /// </summary>
    public class EfTaskDefinition
    {
        /// <summary>
        /// Gets or sets the task values.
        /// </summary>
        /// <value>
        /// The task values.
        /// </value>
        public Dictionary<string, string> TaskValues { get; set; }

        /// <summary>
        /// Gets or sets the type of the task values.
        /// </summary>
        /// <value>
        /// The type of the task values.
        /// </value>
        public string TaskValuesType { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public virtual EfTask Task { get; set; }
    }
}