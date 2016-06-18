using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.Infrastructure.FittsEvaluator
{
    public class TaskEvaluator : ITaskEvaluator
    {
        /// <summary>
        /// Evaluates the user history.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="scenario">The scenario.</param>
        /// <param name="windowSize">Size of the window.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<TaskResultEvaluation> EvaluateUserHistory(User user, Scenario scenario, int windowSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Evaluates the results.
        /// </summary>
        /// <param name="taskResults">The fitts task result pairs.</param>
        /// <returns>
        /// The evaluation of the results.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">All tasks must be Fitts tasks.</exception>
        public TaskResultEvaluation EvaluateResults(List<TaskResult> taskResults)
        {
            if (!taskResults.Any())
                return null;

            double[][] xValues = new double[taskResults.Count][];
            double[] yValues = new double[taskResults.Count];

            for (int i = 0; i < taskResults.Count; i++)
            {
                FittsTaskValues values = taskResults[i].Task.TaskValues as FittsTaskValues;

                if (values == null)
                    throw new InvalidOperationException("All tasks must be Fitts tasks.");

                xValues[i][0] = 1;
                xValues[i][1] = values.IndexOfDifficulty;
                yValues[i] = taskResults[i].TaskResultValues.ElapsedTime;
            }

            var x = DenseMatrix.OfColumnArrays(xValues);
            var y = DenseVector.OfArray(yValues);

            var p = x.QR().Solve(y);

            return new TaskResultEvaluation
            {
                TaskEvaluationValues = new FittsTaskEvaluationValues
                {
                    A = Convert.ToSingle(p[0]),
                    B = Convert.ToSingle(p[1])
                },
                TaskResults = taskResults
            };
        }
    }
}
