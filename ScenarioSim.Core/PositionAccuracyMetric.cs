using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    public class PositionAccuracyMetric : AccuracyMetric
    {
        public override float CalculateError(Vector3f actualValue)
        {
            return Vector3f.DistanceBetween(IdealValue, actualValue);
        }
    }
}
