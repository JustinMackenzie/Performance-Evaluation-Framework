using ScenarioSim.Core.Entities;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class TextLoggingComponent : LoggingComponent
    {
        public TextLoggingComponent(string filePath) : base(filePath)
        {
        }

        protected override string GenerateLogEntry(ScenarioEvent e)
        {
            return string.Format("{0} recieved at {1}.", e.Name, e.Timestamp);
        }
    }
}
