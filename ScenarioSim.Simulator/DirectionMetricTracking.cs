using ScenarioSim.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Simulator
{
    public class DirectionMetricTracking : ParameterMetricTracking
    {
        public DirectionMetricTracking(Vector3f idealValue, string parameterName) : base(idealValue, parameterName) { }
        protected override float Calculate(Vector3f actual, Vector3f idealValue)
        {
            return Vector3f.AngleBetween(idealValue, actual);
        }
    }
}
