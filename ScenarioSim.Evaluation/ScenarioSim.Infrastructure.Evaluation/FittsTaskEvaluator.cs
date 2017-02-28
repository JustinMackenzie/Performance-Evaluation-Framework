using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using MathNet.Numerics.LinearRegression;
using ScenarioSim.Core.Entities;
using ScenarioSim.Evaluation.Entities;
using ScenarioSim.Performance.Entities;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.Infrastructure.Evaluation
{
    public class FittsTaskEvaluator : ITaskEvaluator
    {
        public IEnumerable<TaskPerformanceEvaluation> EvaluateUserHistory(Performer performer, Scenario scenario, int windowSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Evaluates the results.
        /// </summary>
        /// <param name="taskResults">The task results.</param>
        /// <returns>
        /// The evaluation of the results.
        /// </returns>
        public TaskPerformanceEvaluation EvaluateTaskResults(IEnumerable<TaskPerformance> taskResults)
        {
            double[] xValues =
                taskResults.Select(r => (double)(r.Task.TaskValues as FittsTaskValues).IndexOfDifficulty).ToArray();
            double[] yValues =
                taskResults.Select(r => 1.0 * r.TaskPerformanceValues.ElapsedTime / 1000).ToArray();

            Tuple<double, double> results = SimpleRegression.Fit(xValues, yValues);

            dynamic values = new ExpandoObject();
            values.A = Convert.ToSingle(results.Item1);
            values.B = Convert.ToSingle(results.Item2);

            return new TaskPerformanceEvaluation
            {
                TaskEvaluationValues = values,
                TaskPerformances = taskResults
            };
        }

        public PerformanceEvaluation EvaluateScenarioPerformances(Schema schema, IEnumerable<ScenarioPerformance> scenarioPerformances)
        {
            throw new NotImplementedException();
        }
    }
}
