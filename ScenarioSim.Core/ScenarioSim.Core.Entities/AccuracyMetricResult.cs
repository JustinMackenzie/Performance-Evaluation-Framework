namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a result of an accuracy metric from a performance.
    /// </summary>
    public class AccuracyMetricResult
    {
        /// <summary>
        /// The ideal value of the accuracy metric.
        /// </summary>
        public Vector3f IdealValue { get; set; }

        /// <summary>
        /// The actual value of the accuracy metric from the performance.
        /// </summary>
        public Vector3f ActualValue { get; set; }

        /// <summary>
        /// The error value calculated from the actual vs. expected values.
        /// </summary>
        public float Error { get; set; }

        /// <summary>
        /// The name of accuracy metric.
        /// </summary>
        public string ValueName { get; set; }
    }
}
