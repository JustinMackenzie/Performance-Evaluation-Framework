using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    public interface IStateChartEvent
    {
        string Name { get; set; }
        int Id { get; set; }
        DateTime Timestamp { get; set; }
    }
}
