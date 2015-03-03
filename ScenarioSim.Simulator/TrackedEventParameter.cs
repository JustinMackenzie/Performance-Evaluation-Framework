using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class TrackedEventParameter
    {
        public DateTime Timestamp { get; set; }
        public EventParameter Parameter { get; set; }
    }
}
