using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UmlStateChart;
using ScenarioSim.Simulator;

namespace ScenarioSim.UmlStateChart
{
    public class UmlStateChartEvent : IStateChartEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
