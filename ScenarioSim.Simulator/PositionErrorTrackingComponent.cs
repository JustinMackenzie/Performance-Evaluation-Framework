using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class PositionErrorTrackingComponent : ErrorTrackingComponent
    {

        protected override float Calculate(Vector3f actual, Vector3f idealValue)
        {
            return Vector3f.DistanceBetween(idealValue, actual);
        }

        public PositionErrorTrackingComponent(Vector3f idealValue, string parameterName) : base(idealValue, parameterName)
        {
        }
    }
}
