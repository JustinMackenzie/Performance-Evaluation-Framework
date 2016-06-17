using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.Infrastructure.FittsEvaluator
{
    public class FittsEvaluator : IFittsEvaluator
    {
        private readonly IScenarioResultRepository resultRepository;
        private Dictionary<Guid, List<TaskResult>> taskDifficultySpeedCollection;
        private Dictionary<Guid, FittsTaskResultEvaluation> fittsTaskEvaluations;
        private TreeNode<List<TaskResult>> taskSpeedTimes;
        private TreeNode<FittsTaskResultEvaluation> fittsTaskEvaluationTree;

        public FittsEvaluator(IScenarioResultRepository resultRepository)
        {
            this.resultRepository = resultRepository;
        }

        public IEnumerable<FittsEvaluationResult> EvaluateUserHistory(User user, Scenario scenario, int windowSize)
        {
            List<ScenarioResult> results = resultRepository.GetAllResultsByUser(user, scenario).ToList();
            List<FittsEvaluationResult> fittsEvaluationResults = new List<FittsEvaluationResult>();

            for (int i = windowSize; i < results.Count; i++)
            {
                ScenarioResult[] windowResults = new ScenarioResult[windowSize];

                results.CopyTo(i - windowSize, windowResults, 0, windowSize);

                FittsEvaluationResult result = Evaluate(scenario, windowResults);

                fittsEvaluationResults.Add(result);
            }

            return fittsEvaluationResults;
        }

        private void BuildFittsTaskEvaluations(TreeNode<TaskResult> resultsNode)
        {
            Guid id = resultsNode.Value.Task.Id;

            if (taskDifficultySpeedCollection.ContainsKey(id))
                taskDifficultySpeedCollection[id].Add(resultsNode.Value);
            else
                taskDifficultySpeedCollection.Add(id,
                    new List<TaskResult> { resultsNode.Value });

            foreach (TreeNode<TaskResult> child in resultsNode.Children)
                BuildFittsTaskEvaluations(child);
        }

        public FittsTaskResultEvaluation EvaluateResults(List<TaskResult> fittsTaskResultPairs)
        {
            if (!fittsTaskResultPairs.Any())
                return null;

            double[][] xValues = new double[fittsTaskResultPairs.Count][];
            double[] yValues = new double[fittsTaskResultPairs.Count];

            for (int i = 0; i < fittsTaskResultPairs.Count; i++)
            {
                FittsTaskValues values = fittsTaskResultPairs[i].Task.TaskValues as FittsTaskValues;

                if (values == null)
                    throw new InvalidOperationException("All tasks must be Fitts tasks.");

                xValues[i][0] = 1;
                xValues[i][1] = values.IndexOfDifficulty;
                yValues[i] = fittsTaskResultPairs[i].TaskResultValues.ElapsedTime;
            }

            var x = DenseMatrix.OfColumnArrays(xValues);
            var y = DenseVector.OfArray(yValues);

            var p = x.QR().Solve(y);

            return new FittsTaskResultEvaluation
            {
                A = Convert.ToSingle(p[0]),
                B = Convert.ToSingle(p[1])
            };
        }

        private FittsEvaluationResult Evaluate(Scenario scenario, IEnumerable<ScenarioResult> results)
        {
            taskDifficultySpeedCollection = new Dictionary<Guid, List<TaskResult>>();

            // Go through each scenario building the fitts task evaluations
            foreach (ScenarioResult simulationResult in results)
                BuildFittsTaskEvaluations(simulationResult.TaskResultTree);

            fittsTaskEvaluations = new Dictionary<Guid, FittsTaskResultEvaluation>();

            foreach (KeyValuePair<Guid, List<TaskResult>> pairs in
                taskDifficultySpeedCollection)
                fittsTaskEvaluations.Add(pairs.Key, EvaluateResults(pairs.Value));

            TreeNode<FittsTaskEvaluation> fittsTaskResultEvaluation = BuildFittsTaskEvaluationTree(scenario.TaskTree);

            return new FittsEvaluationResult { FittsTaskResultEvaluation = fittsTaskResultEvaluation };
        }

        private TreeNode<FittsTaskEvaluation> BuildFittsTaskEvaluationTree(TreeNode<Task> task)
        {
            Guid id = task.Value.Id;
            FittsTaskEvaluation fittsTaskResultEvaluation = new FittsTaskEvaluation
            {
                Task = task.Value,
                Evaluation = fittsTaskEvaluations[id]
            };
            TreeNode<FittsTaskEvaluation> fittsTaskResultEvaluationNode = new TreeNode<FittsTaskEvaluation>(fittsTaskResultEvaluation);

            foreach (TreeNode<Task> child in task.Children)
                fittsTaskResultEvaluationNode.AppendChild(BuildFittsTaskEvaluationTree(child));

            return fittsTaskResultEvaluationNode;
        }
    }
}
