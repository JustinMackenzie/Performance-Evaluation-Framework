using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    interface ISimulatorEventLogger
    {
        void Log(SimulatorEvent e);
    }
}
