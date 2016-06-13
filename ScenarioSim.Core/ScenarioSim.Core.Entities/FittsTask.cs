using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a task in the Fitts' Law paradigm
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.Task" />
    public class FittsTask : Task
    {
        /// <summary>
        /// Gets or sets the D parameter.
        /// </summary>
        /// <value>
        /// The D parameter in the Fitts' Law equation.
        /// </value>
        public float D { get; set; }

        /// <summary>
        /// Gets or sets the W parameter.
        /// </summary>
        /// <value>
        /// The W parameter in the Fitts' Law equation.
        /// </value>
        public float W { get; set; }

        /// <summary>
        /// Gets the index of difficulty.
        /// </summary>
        /// <value>
        /// The index of difficulty.
        /// </value>
        public float IndexOfDifficulty => (float)Math.Log(2.0 * D / W, 2);
    }
}
