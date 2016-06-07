using System;

namespace ScenarioSim.Services.Simulator
{
    public interface ISimulatorPlatform
    {
        event EventHandler<SimulatorEventArgs> ProducedEvent;

        void SendCommand(ISimulatorCommand command);
    }
}
