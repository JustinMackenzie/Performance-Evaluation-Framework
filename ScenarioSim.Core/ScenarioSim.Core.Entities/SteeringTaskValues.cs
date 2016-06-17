namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.TaskValues" />
    public class SteeringTaskValues : TaskValues
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
    }
}