using ScenarioSim.Core.Entities;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class CsvLoggingComponent : LoggingComponent
    {
        public CsvLoggingComponent(string filePath) : base(filePath)
        {
        }

        protected override string GenerateLogEntry(ScenarioEvent e)
        {
            return string.Format("{0},{1},{2}",
                e.Timestamp, e.Id, e.Name);
        }
    }
}
