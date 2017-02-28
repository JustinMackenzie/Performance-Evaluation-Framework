using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Evaluation.Entities;
using ScenarioSim.Performance.Entities;
using ScenarioSim.Services.Evaluation;
using ScenarioSim.Utility;

namespace ScenarioSim.Infrastructure.Evaluation
{
    /// <summary>
    /// Represents an evaluator that evaluates a task and series of task results.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.Evaluation.ITaskEvaluator" />
    public class TaskEvaluator : ITaskEvaluator
    {
        /// <summary>
        /// The evaluator factory
        /// </summary>
        private readonly IEvaluatorFactory evaluatorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskEvaluator" /> class.
        /// </summary>
        /// <param name="evaluatorFactory">The evaluator factory.</param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public TaskEvaluator(IEvaluatorFactory evaluatorFactory)
        {
            if (evaluatorFactory == null)
                throw new ArgumentNullException(nameof(evaluatorFactory));

            this.evaluatorFactory = evaluatorFactory;
        }

        /// <summary>
        /// Evaluates the user history.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="scenario">The scenario.</param>
        /// <param name="windowSize">Size of the window.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<TaskPerformanceEvaluation> EvaluateUserHistory(Performer user, Scenario scenario, int windowSize)
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
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException">All task results must be from the same task.</exception>
        public TaskPerformanceEvaluation EvaluateTaskResults(IEnumerable<TaskPerformance> taskResults)
        {
            if (taskResults == null)
                throw new ArgumentNullException(nameof(taskResults));

            if (taskResults.Select(r => r.Task.Id).Distinct().Count() > 1)
                throw new ArgumentException("All task results must be from the same task.", nameof(taskResults));

            IEvaluator evaluator = evaluatorFactory.MakeEvaluator(taskResults.First());
            return evaluator.Evaluate(taskResults);
        }

        /// <summary>
        /// Evaluates the scenario results.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="scenarioPerformances">The scenario performances.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">All given scenario results must be from the given schema.</exception>
        public PerformanceEvaluation EvaluateScenarioPerformances(Schema schema, IEnumerable<ScenarioPerformance> scenarioPerformances)
        {
            if (scenarioPerformances == null)
                throw new ArgumentNullException(nameof(scenarioPerformances));

            if (scenarioPerformances.Count(r => r.Scenario.Schema != schema) > 1)
                throw new ArgumentException("All given scenario results must be from the given schema.", nameof(scenarioPerformances));

            PerformanceEvaluation performanceEvaluation = new PerformanceEvaluation
            {
                ScenarioResults = scenarioPerformances,
                Schema = schema
            };

            Dictionary<Guid, List<TaskPerformance>> resultsByTask = new Dictionary<Guid, List<TaskPerformance>>();

            foreach (ScenarioPerformance result in scenarioPerformances)
                BuildResultDictionary(result.TaskPerformanceTree, resultsByTask);

            performanceEvaluation.TaskPerformanceEvaluations = resultsByTask.ToDictionary(pair => pair.Key, pair => EvaluateTaskResults(pair.Value));

            return performanceEvaluation;
        }

        /// <summary>
        /// Builds the performance dictionary.
        /// </summary>
        /// <param name="taskResultTree">The task performance tree.</param>
        /// <param name="resultsByTask">The results by task.</param>
        private void BuildResultDictionary(TreeNode<TaskPerformance> taskResultTree, Dictionary<Guid, List<TaskPerformance>> resultsByTask)
        {
            Guid id = taskResultTree.Value.Task.Id;

            if (resultsByTask.ContainsKey(id))
                resultsByTask[id].Add(taskResultTree.Value);
            else
                resultsByTask.Add(id, new List<TaskPerformance> { taskResultTree.Value });

            foreach (TreeNode<TaskPerformance> child in taskResultTree.Children)
                BuildResultDictionary(child, resultsByTask);
        }
    }
}
