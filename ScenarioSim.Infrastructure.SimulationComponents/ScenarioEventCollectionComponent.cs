using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class ScenarioEventCollectionComponent : ISimulationComponent
    {
        private ScenarioEventCollection eventCollection;
        private readonly string filePath;
        private readonly IFileSerializer<ScenarioEventCollection> serializer;

        public ScenarioEventCollectionComponent(string filePath,
            IFileSerializer<ScenarioEventCollection> serializer)
        {
            this.filePath = filePath;
            this.serializer = serializer;
        }

        public void Start()
        {
            eventCollection = new ScenarioEventCollection();
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
