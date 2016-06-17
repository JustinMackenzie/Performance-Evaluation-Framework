using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Evaluation
{
    public class FittsTaskEvaluation
    {
        public Task Task { get; set; }
        public FittsTaskResultEvaluation Evaluation { get; set; }
    }
}