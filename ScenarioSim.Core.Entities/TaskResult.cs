using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    public class TaskResult
    {
        public string TaskName { get; set; }
        public List<AccuracyMetricResult> Results { get; set; }
        public long Speed { get; set; }

        public TaskResult()
        {
            Results = new List<AccuracyMetricResult>();
        }
    }
}
