using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    class SimulatorEvent
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}
