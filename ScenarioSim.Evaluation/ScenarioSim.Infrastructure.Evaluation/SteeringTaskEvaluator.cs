using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Evaluation.Entities;
using ScenarioSim.Performance.Entities;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.Infrastructure.Evaluation
{
    public class SteeringTaskEvaluator : ITaskEvaluator
    {
        public IEnumerable<TaskPerformanceEvaluation> EvaluateUserHistory(Performer performer, Scenario scenario, int windowSize)
        {
            throw new System.NotImplementedException();
        }

        public TaskPerformanceEvaluation EvaluateTaskResults(IEnumerable<TaskPerformance> taskResults)
        {
            throw new System.NotImplementedException();
        }

        public PerformanceEvaluation EvaluateScenarioPerformances(Schema schema, IEnumerable<ScenarioPerformance> scenarioPerformances)
        {
            throw new System.NotImplementedException();
        }
    }
}