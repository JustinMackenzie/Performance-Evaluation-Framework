using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class DirectionErrorTrackingComponent : ErrorTrackingComponent
    {
        public DirectionErrorTrackingComponent(Vector3f idealValue, string parameterName) : base(idealValue, parameterName) { }
        protected override float Calculate(Vector3f actual, Vector3f idealValue)
        {
            return Vector3f.AngleBetween(idealValue, actual);
        }
    }
}
