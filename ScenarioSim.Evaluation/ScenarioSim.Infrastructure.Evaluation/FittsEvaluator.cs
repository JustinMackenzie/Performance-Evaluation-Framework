﻿using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearRegression;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.Infrastructure.Evaluation
{
    /// <summary>
    /// Represents an evaluator that evaluates Fitts task results.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.Evaluation.IEvaluator" />
    public class FittsEvaluator : IEvaluator
    {
        /// <summary>
        /// Evaluates the specified task results.
        /// </summary>
        /// <param name="taskResults">The task results.</param>
        /// <returns></returns>
        public TaskPerformanceEvaluation Evaluate(IEnumerable<TaskPerformance> taskResults)
        {
            double[] xValues =
                taskResults.Select(r => (double)(r.Task.TaskValues as FittsTaskValues).IndexOfDifficulty).ToArray();
            double[] yValues =
                taskResults.Select(r => 1.0 * r.TaskPerformanceValues.ElapsedTime / 1000).ToArray();

            Tuple<double, double> results = SimpleRegression.Fit(xValues, yValues);

            return new TaskPerformanceEvaluation
            {
                TaskEvaluationValues = new FittsTaskEvaluationValues
                {
                    A = Convert.ToSingle(results.Item1),
                    B = Convert.ToSingle(results.Item2)
                },
                TaskPerformances = taskResults
            };
        }
    }
}
