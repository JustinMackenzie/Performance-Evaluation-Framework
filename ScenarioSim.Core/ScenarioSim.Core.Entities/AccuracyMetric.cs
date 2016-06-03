using System.Xml.Serialization;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// An abstract class that represents an accuracy metric 
    /// that will be measured during the performance of a task.
    /// </summary>
    [XmlInclude(typeof(DirectionAccuracyMetric)),
    XmlInclude(typeof(PositionAccuracyMetric))]
    public abstract class AccuracyMetric
    {
        /// <summary>
        /// The ideal value of the metric.
        /// </summary>
        public Vector3f IdealValue { get; set; }
        /// <summary>
        /// The actual value of the metric.
        /// </summary>
        public ActualValueLocation ActualValue { get; set; }

        /// <summary>
        /// The name of the metric.
        /// </summary>
        public string ValueName { get; set; }

        /// <summary>
        /// Determines the error based on the actual value vs. the expected value.
        /// </summary>
        /// <param name="actualValue"></param>
        /// <returns></returns>
        public abstract float CalculateError(Vector3f actualValue);
    }
}
