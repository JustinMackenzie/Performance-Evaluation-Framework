using System;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    public class SimulatorEventArgs : EventArgs
    {
        public ScenarioEvent ScenarioEvent { get; set; }
    }
}