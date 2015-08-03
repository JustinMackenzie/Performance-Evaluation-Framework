namespace ScenarioSim.Core
{
    public class AccuracyMetricResult
    {
        public Vector3f IdealValue { get; set; }
        public Vector3f ActualValue { get; set; }
        public float Error { get; set; }
        public string ValueName { get; set; }
    }
}
