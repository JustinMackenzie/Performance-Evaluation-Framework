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
        private IScenarioResultRepository resultRepository;
        private Dictionary<string, List<FittsTaskResultPair>> taskDifficultySpeedCollection;
        private Dictionary<string, FittsTaskResultEvaluation> fittsTaskEvaluations;
        private TreeNode<List<FittsTaskResultPair>> taskSpeedTimes;
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
            if (resultsNode.Value is FittsTaskResult)
            {
                string taskName = resultsNode.Value.Task.Name;

                FittsTaskResultPair pair = new FittsTaskResultPair
                {
                    Result = resultsNode.Value as FittsTaskResult,
                    Task = resultsNode.Value.Task as FittsTask
                };

                if (taskDifficultySpeedCollection.ContainsKey(taskName))
                    taskDifficultySpeedCollection[taskName].Add(pair);
                else
                    taskDifficultySpeedCollection.Add(taskName,
                        new List<FittsTaskResultPair> { pair });
            }

            foreach (TreeNode<TaskResult> child in resultsNode.Children)
                BuildFittsTaskEvaluations(child);
        }

        public FittsTaskResultEvaluation EvaluateResults(List<FittsTaskResultPair> fittsTaskResultPairs)
        {
            if (!fittsTaskResultPairs.Any())
                return null;

            double[][] xValues = new double[fittsTaskResultPairs.Count][];
            double[] yValues = new double[fittsTaskResultPairs.Count];

            for (int i = 0; i < fittsTaskResultPairs.Count; i++)
            {
                xValues[i][0] = 1;
                xValues[i][1] = fittsTaskResultPairs[i].Task.IndexOfDifficulty;
                yValues[i] = fittsTaskResultPairs[i].Result.Speed;
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
            taskDifficultySpeedCollection = new Dictionary<string, List<FittsTaskResultPair>>();

            // Go through each scenario building the fitts task evaluations
            foreach (ScenarioResult simulationResult in results)
                BuildFittsTaskEvaluations(simulationResult.TaskResult);

            fittsTaskEvaluations = new Dictionary<string, FittsTaskResultEvaluation>();

            foreach (KeyValuePair<string, List<FittsTaskResultPair>> pairs in
                taskDifficultySpeedCollection)
                fittsTaskEvaluations.Add(pairs.Key, EvaluateResults(pairs.Value));

            TreeNode<FittsTaskEvaluation> fittsTaskResultEvaluation = BuildFittsTaskEvaluationTree(scenario.Task);

            return new FittsEvaluationResult { FittsTaskResultEvaluation = fittsTaskResultEvaluation };
        }

        private TreeNode<FittsTaskEvaluation> BuildFittsTaskEvaluationTree(TreeNode<Task> task)
        {
            string taskName = task.Value.Name;
            FittsTaskEvaluation fittsTaskResultEvaluation = new FittsTaskEvaluation
            {
                Task = task.Value as FittsTask,
                Evaluation = fittsTaskEvaluations[taskName]
            };
            TreeNode<FittsTaskEvaluation> fittsTaskResultEvaluationNode = new TreeNode<FittsTaskEvaluation>(fittsTaskResultEvaluation);

            foreach (TreeNode<Task> child in task.Children)
            {
                fittsTaskResultEvaluationNode.AppendChild(BuildFittsTaskEvaluationTree(child));
            }

            return fittsTaskResultEvaluationNode;
        }
    }
}
