using System;

namespace ScenarioSim.Core.Entities
{
    public class ScenarioEvent
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public EventParameterCollection Parameters { get; set; }
    }
}
