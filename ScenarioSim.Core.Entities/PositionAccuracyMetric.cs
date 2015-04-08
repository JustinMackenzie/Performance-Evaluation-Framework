namespace ScenarioSim.Core.Entities
{
    public class PositionAccuracyMetric : AccuracyMetric
    {
        public override float CalculateError(Vector3f actualValue)
        {
            return Vector3f.DistanceBetween(IdealValue, actualValue);
        }
    }
}
