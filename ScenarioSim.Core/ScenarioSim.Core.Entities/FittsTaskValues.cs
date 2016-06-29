using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents task data values specific to a Fitts task.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.TaskValues" />
    public class FittsTaskValues : TaskValues
    {
        /// <summary>
        /// Gets the D parameter.
        /// </summary>
        /// <value>
        /// The D parameter in the Fitts' Law equation.
        /// </value>
        public float D { get; set; }

        /// <summary>
        /// Gets the W parameter.
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

        /// <summary>
        /// Initializes a new instance of the <see cref="FittsTaskValues"/> class.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="w">The w.</param>
        public FittsTaskValues(float d, float w)
        {
            D = d;
            W = w;
        }
    }
}