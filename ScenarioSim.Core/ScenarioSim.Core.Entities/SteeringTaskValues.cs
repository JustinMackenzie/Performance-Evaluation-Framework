namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents the task data values of a steering task.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.TaskValues" />
    public class SteeringTaskValues : TaskValues
    {
        /// <summary>
        /// Gets A.
        /// </summary>
        /// <value>
        /// The length of the tunnel.
        /// </value>
        public float A { get; set; }

        /// <summary>
        /// Gets W.
        /// </summary>
        /// <value>
        /// The width of the tunnel.
        /// </value>
        public float W { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SteeringTaskValues"/> class.
        /// </summary>
        /// <param name="a">The length of the tunnel.</param>
        /// <param name="w">The width of the tunnel.</param>
        public SteeringTaskValues(float a, float w)
        {
            A = a;
            W = w;
        }
    }
}