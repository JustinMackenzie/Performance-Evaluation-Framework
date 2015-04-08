namespace ScenarioSim.Core.Entities
{
    public class DirectionAccuracyMetric : AccuracyMetric
    {
        public override float CalculateError(Vector3f actualValue)
        {
            return Vector3f.AngleBetween(actualValue, IdealValue);
        }
    }
}
