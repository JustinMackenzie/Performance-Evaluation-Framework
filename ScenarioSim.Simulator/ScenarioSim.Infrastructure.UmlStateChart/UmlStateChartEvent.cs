using System;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.UmlStateChart
{
    public class UmlStateChartEvent : IStateChartEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
