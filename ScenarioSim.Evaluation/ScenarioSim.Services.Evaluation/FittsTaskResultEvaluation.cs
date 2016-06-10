namespace ScenarioSim.Services.Evaluation
{
    /// <summary>
    /// Represents the evaluation of a fitts task result.
    /// </summary>
    public class FittsTaskResultEvaluation
    {
        /// <summary>
        /// Gets or sets A.
        /// </summary>
        /// <value>
        /// The 'a' parameter in the fitts law equation. Represents the reaction time.
        /// </value>
        public float A { get; set; }

        /// <summary>
        /// Gets or sets B.
        /// </summary>
        /// <value>
        /// The 'b' parameter in the fitts law equation. Represents the control rate.
        /// </value>
        public float B { get; set; }

        /// <summary>
        /// Gets the index of performance.
        /// </summary>
        /// <value>
        /// The index of performance.
        /// </value>
        public float IndexOfPerformance => 1 / B;
    }
}