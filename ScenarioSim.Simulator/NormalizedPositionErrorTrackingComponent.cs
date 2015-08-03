using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    class NormalizedPositionErrorTrackingComponent : PositionErrorTrackingComponent
    {
        private float scalingFactor;

        public NormalizedPositionErrorTrackingComponent(Vector3f idealValue, string parameterName, float scalingFactor) : base(idealValue, parameterName)
        {
            this.scalingFactor = scalingFactor;
        }

        protected override float Calculate(Vector3f actual, Vector3f idealValue)
        {
            if (errors.Count == 0)
                return scalingFactor;

            return scalingFactor * (1 - (errors[0].Error - base.Calculate(actual, idealValue)) / errors[0].Error);
        }
    }
}
