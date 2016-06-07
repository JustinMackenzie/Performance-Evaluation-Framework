using System;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    public interface ISimulatorPlatform
    {
        event EventHandler<SimulatorEventArgs> ProducedEvent;

        void SendCommand(ISimulatorCommand command);
    }

    public class SimulatorEventArgs : EventArgs
    {
        public ScenarioEvent ScenarioEvent { get; set; }
    }

    public interface ISimulatorCommand
    {
    }
}
