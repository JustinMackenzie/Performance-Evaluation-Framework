using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    public class FittsTaskEvaluation
    {
        public FittsTask Task { get; set; }
        public FittsTaskResultEvaluation Evaluation { get; set; }
    }
}