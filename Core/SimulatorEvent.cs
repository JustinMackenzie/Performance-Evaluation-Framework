using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    public class SimulatorEvent
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public List<EventParameter> Parameters { get; set; }
    }
}
