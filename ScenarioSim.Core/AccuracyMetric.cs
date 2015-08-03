using System.Xml.Serialization;

namespace ScenarioSim.Core
{
    [XmlInclude(typeof(DirectionAccuracyMetric)),
    XmlInclude(typeof(PositionAccuracyMetric))]
    public abstract class AccuracyMetric
    {
        public Vector3f IdealValue { get; set; }
        public ActualValueLocation ActualValue { get; set; }
        public string ValueName { get; set; }
        public abstract float CalculateError(Vector3f actualValue);
    }
}
