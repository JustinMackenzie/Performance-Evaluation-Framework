using System.Collections.Generic;

namespace ScenarioSim.Core
{
    class SimulatorEventHandler : ISimulatorEventHandler
    {
        ScenarioEventCollection events;
        List<ISimulatorEventLogger> loggers;

        public SimulatorEventHandler(List<ISimulatorEventLogger> loggers)
        {
            events = new ScenarioEventCollection();
            this.loggers = loggers;
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            events.Add(e);
            foreach (ISimulatorEventLogger logger in loggers)
                logger.Log(e);
        }

        public void Save(string filename)
        {
            IFileSerializer<ScenarioEventCollection> serializer = new XmlFileSerializer<ScenarioEventCollection>();
            serializer.Serialize(filename, events);
        }


        public ScenarioEventCollection Events
        {
            get { return events; }
        }
    }
}
