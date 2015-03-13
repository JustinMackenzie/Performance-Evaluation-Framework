using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class NormalizedDirectionMetricTracking : DirectionMetricTracking
    {
        float scalingFactor;

        public NormalizedDirectionMetricTracking(Vector3f idealValue, string parameterName, float scalingFactor) : base(idealValue, parameterName) { }

        protected override float Calculate(Vector3f actual, Vector3f idealValue)
        {
            if (errors.Count == 0)
                return scalingFactor;

            return scalingFactor * (1 - (errors[0].Error - base.Calculate(actual, idealValue)) / errors[0].Error);
        }
    }
}
