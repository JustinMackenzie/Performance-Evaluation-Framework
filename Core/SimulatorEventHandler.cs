using System.Collections.Generic;

namespace ScenarioSim.Core
{
    class SimulatorEventHandler : ISimulatorEventHandler
    {
        List<SimulatorEvent> events;
        List<ISimulatorEventLogger> loggers;

        public SimulatorEventHandler(List<ISimulatorEventLogger> loggers)
        {
            events = new List<SimulatorEvent>();
            this.loggers = loggers;
        }

        public void SubmitEvent(SimulatorEvent e)
        {
            events.Add(e);
            foreach (ISimulatorEventLogger logger in loggers)
                logger.Log(e);
        }
    }
}
