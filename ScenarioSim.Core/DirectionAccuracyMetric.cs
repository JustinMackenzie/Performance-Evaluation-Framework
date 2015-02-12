using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    public class DirectionAccuracyMetric : AccuracyMetric
    {
        public override float CalculateError(Vector3f actualValue)
        {
            return Vector3f.AngleBetween(actualValue, IdealValue);
        }
    }
}
