using System.Collections.Generic;

namespace ScenarioSim.Core
{
    class SimulatorEventHandler : ISimulatorEventHandler
    {
        SimulatorEventCollection events;
        List<ISimulatorEventLogger> loggers;

        public SimulatorEventHandler(List<ISimulatorEventLogger> loggers)
        {
            events = new SimulatorEventCollection();
            this.loggers = loggers;
        }

        public void SubmitEvent(SimulatorEvent e)
        {
            events.Add(e);
            foreach (ISimulatorEventLogger logger in loggers)
                logger.Log(e);
        }

        public void Save(string filename)
        {
            IFileSerializer<SimulatorEventCollection> serializer = new XmlFileSerializer<SimulatorEventCollection>();
            serializer.Serialize(filename, events);
        }
    }
}
