using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    interface ISimulatorEventLogger
    {
        void Log(SimulatorEvent e);
    }
}
