using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class ErrorMetricEntry
    {
        public DateTime Timestamp { get; set; }
        public float Error { get; set; }
    }
}
