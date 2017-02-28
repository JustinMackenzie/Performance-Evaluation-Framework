using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Evaluation.Entities;
using ScenarioSim.Performance.Entities;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.Infrastructure.Evaluation
{
    /// <summary>
    /// Represents an evaluator that evaluates reaction task results.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.Evaluation.IEvaluator" />
    public class ReactionTaskEvaluator : ITaskEvaluator
    {
        public IEnumerable<TaskPerformanceEvaluation> EvaluateUserHistory(Performer performer, Scenario scenario, int windowSize)
        {
            throw new NotImplementedException();
        }

        public TaskPerformanceEvaluation EvaluateTaskResults(IEnumerable<TaskPerformance> taskResults)
        {
            throw new NotImplementedException();
        }

        public PerformanceEvaluation EvaluateScenarioPerformances(Schema schema, IEnumerable<ScenarioPerformance> scenarioPerformances)
        {
            throw new NotImplementedException();
        }
    }
}
