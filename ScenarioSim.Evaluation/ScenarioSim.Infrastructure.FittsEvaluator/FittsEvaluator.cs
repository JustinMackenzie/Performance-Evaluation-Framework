using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Evaluation;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.FittsEvaluator
{
    public class FittsEvaluator : IEvaluator
    {
        private IScenarioResultRepository resultRepository;
        private Dictionary<string, List<SpeedDifficultyPair>> taskDifficultySpeedCollection;
        private Dictionary<string, FittsParameters> parameters; 
        private TreeNode<List<SpeedDifficultyPair>> taskSpeedTimes;
        private TreeNode<FittsParameters> fittsParameters;

        public FittsEvaluator(IScenarioResultRepository resultRepository)
        {
            this.resultRepository = resultRepository;
        }

        public void Evaluate(ScenarioResult result)
        {
            Scenario scenario = result.Scenario;

            IEnumerable<ScenarioResult> results = resultRepository.GetAllResultsByScenario(scenario);

            taskDifficultySpeedCollection = new Dictionary<string, List<SpeedDifficultyPair>>();

            foreach (ScenarioResult simulationResult in results)
                BuildDifficultySpeedCollection(simulationResult.TaskResult);

            parameters = new Dictionary<string, FittsParameters>();

            foreach (KeyValuePair<string, List<SpeedDifficultyPair>> pairs in 
                taskDifficultySpeedCollection)
                parameters.Add(pairs.Key, DetermineParameters(pairs.Value));

            result.TaskResult.Traverse(EvaluateTask);
        }

        public void EvaluateUser(User user, Scenario scenario)
        {
            throw new NotImplementedException();
        }

        private void EvaluateTask(TaskResult result)
        {
            if (!parameters.ContainsKey(result.TaskName))
                return;

            FittsParameters parameter = parameters[result.TaskName];


        }

        private void BuildDifficultySpeedCollection(TreeNode<TaskResult> resultsNode)
        {
            string task = resultsNode.Value.TaskName;
            float speed = resultsNode.Value.Speed;
            float id = 0;

            SpeedDifficultyPair pair = new SpeedDifficultyPair
            {
                Difficulty = id,
                Speed = speed
            };

            if (taskDifficultySpeedCollection.ContainsKey(task))
            {
                taskDifficultySpeedCollection[task].Add(pair);
            }
            else
            {
                taskDifficultySpeedCollection.Add(task, 
                    new List<SpeedDifficultyPair> { pair });
            }

            foreach (TreeNode<TaskResult> child in resultsNode.children)
                BuildDifficultySpeedCollection(child);
        }

        private FittsParameters DetermineParameters(List<SpeedDifficultyPair> speedDifficultyPairs)
        {
            if (!speedDifficultyPairs.Any())
                return null;

            double[][] xValues = new double[speedDifficultyPairs.Count][];
            double[] yValues = new double[speedDifficultyPairs.Count];

            for (int i = 0; i < speedDifficultyPairs.Count; i++)
            {
                xValues[i][0] = 1;
                xValues[i][1] = speedDifficultyPairs[i].Difficulty;
                yValues[i] = speedDifficultyPairs[i].Speed;
            }

            var x = DenseMatrix.OfColumnArrays(xValues);
            var y = DenseVector.OfArray(yValues);

            var p = x.QR().Solve(y);

            return new FittsParameters()
            {
                A = Convert.ToSingle(p[0]),
                B = Convert.ToSingle(p[1])
            };
        }

        class FittsParameters
        {
            public float A { get; set; }
            public float B { get; set; }
        }

        struct SpeedDifficultyPair
        {
            public float Difficulty { get; set; }
            public float Speed { get; set; }
        }
    }
}
