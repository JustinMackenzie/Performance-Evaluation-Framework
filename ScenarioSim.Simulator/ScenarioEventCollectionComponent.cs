using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class ScenarioEventCollectionComponent : ISimulationComponent
    {
        private ScenarioEventCollection eventCollection;
        private readonly string filePath;
        private readonly IFileSerializer<ScenarioEventCollection> serializer;

        public ScenarioEventCollectionComponent(string filePath)
            : this(filePath, new XmlFileSerializer<ScenarioEventCollection>())
        {
            this.filePath = filePath;
        }

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
