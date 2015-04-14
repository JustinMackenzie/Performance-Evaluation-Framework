using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    public class SimulationResult
    {
        public User User { get; set; }
        public string ScenarioFile { get; set; }
        public TreeNode<TaskResult> TaskResult { get; set; }
        public List<ScenarioEvent> Events { get; set; }
        public List<TrackedEventParameter> TrackedParameters { get; set; }
        public Scenario Scenario { get; set; }
    }
}
