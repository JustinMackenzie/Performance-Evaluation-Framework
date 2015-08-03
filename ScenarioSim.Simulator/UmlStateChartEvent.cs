using System;
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
