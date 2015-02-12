using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
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
