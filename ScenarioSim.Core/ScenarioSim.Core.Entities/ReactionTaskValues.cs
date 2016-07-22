namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class ReactionTaskValues : TaskValues
    {
        /// <summary>
        /// Gets the delay.
        /// </summary>
        /// <value>
        /// The delay.
        /// </value>
        public float Delay { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReactionTaskValues"/> class.
        /// </summary>
        /// <param name="delay">The delay.</param>
        public ReactionTaskValues(float delay)
        {
            Delay = delay;
        }
    }
}