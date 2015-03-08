using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    interface ISimulationComponent
    {
        void Start();
        void SubmitEvent(ScenarioEvent e);
        void Complete();
    }
}
