using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.TaskValues" />
    public class FittsTaskValues : TaskValues
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