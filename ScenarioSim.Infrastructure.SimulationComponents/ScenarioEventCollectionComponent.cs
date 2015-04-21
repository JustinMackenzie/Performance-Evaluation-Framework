using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class ScenarioEventCollectionComponent : ISimulationComponent
    {
        public IEnumerable<ScenarioEvent> Events {
            get { return eventCollection; }
        }

        private List<ScenarioEvent> eventCollection;
        private readonly string filePath;
        private readonly IFileSerializer<List<ScenarioEvent>> serializer;

        public ScenarioEventCollectionComponent(string filePath,
            IFileSerializer<List<ScenarioEvent>> serializer)
        {
            this.filePath = filePath;
            this.serializer = serializer;
        }

        public void Start(Scenario scenario)
        {
            eventCollection = new List<ScenarioEvent>();
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            eventCollection.Add(e);
        }

        public void Complete()
        {
            serializer.Serialize(filePath, eventCollection);
        }
    }
}
