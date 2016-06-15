﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// A Fitts' law derived task that requires the user to navigate through a path.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.Task" />
    public class SteeringTask : Task
    {
        /// <summary>
        /// Gets or sets A.
        /// </summary>
        /// <value>
        /// The length of the tunnel.
        /// </value>
        public float A { get; set; }

        /// <summary>
        /// Gets or sets W.
        /// </summary>
        /// <value>
        /// The width of the tunnel.
        /// </value>
        public float W { get; set; }

        /// <summary>
        /// Sets the specific values.
        /// </summary>
        /// <param name="specificTask">The specific task.</param>
        public override void SetSpecificValues(Task specificTask)
        {
            SteeringTask steeringTask = specificTask as SteeringTask;

            if (steeringTask == null)
                return;

            A = steeringTask.A;
            W = steeringTask.W;
        }
    }
}
