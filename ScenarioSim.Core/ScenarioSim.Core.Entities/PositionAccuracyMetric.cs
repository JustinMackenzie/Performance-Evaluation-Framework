namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents the means to determine the accuracy metrics error for position.  
    /// </summary>
    public class PositionAccuracyMetric : AccuracyMetric
    {
        /// <summary>
        /// Calculates the position error between the expected and the actual value.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <returns>The euclidean distance between the expected and actual positions.</returns>
        public override float CalculateError(Vector3f actualValue)
        {
            return Vector3f.DistanceBetween(IdealValue, actualValue);
        }
    }
}
