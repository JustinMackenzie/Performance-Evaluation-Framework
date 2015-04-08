using System.IO;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public abstract class LoggingComponent : ISimulationComponent
    {
        private StreamWriter writer;
        private readonly string filePath;

        protected LoggingComponent(string filePath)
        {
            this.filePath = filePath;
        }

        public void Start()
        {
            writer = new StreamWriter(filePath);
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            writer.WriteLine(GenerateLogEntry(e));
        }

        public void Complete()
        {
            writer.Dispose();
        }

        protected abstract string GenerateLogEntry(ScenarioEvent e);
    }
}
