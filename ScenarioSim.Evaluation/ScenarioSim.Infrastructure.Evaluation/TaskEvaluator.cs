using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.Infrastructure.Evaluator
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
        public IEnumerable<TaskResultEvaluation> EvaluateUserHistory(User user, Scenario scenario, int windowSize)
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
        public TaskResultEvaluation EvaluateTaskResults(IEnumerable<TaskResult> taskResults)
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
        /// <param name="scenarioResults">The scenario results.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">All given scenario results must be from the same schema.</exception>
        public ScenarioResultEvaluation EvaluateScenarioResults(IEnumerable<ScenarioResult> scenarioResults)
        {
            if (scenarioResults == null)
                throw new ArgumentNullException(nameof(scenarioResults));

            if (scenarioResults.Select(r => r.Scenario.Schema.Id).Distinct().Count() > 1)
                throw new ArgumentException("All given scenario results must be from the same schema.", nameof(scenarioResults));

            ScenarioResultEvaluation scenarioResultEvaluation = new ScenarioResultEvaluation
            {
                ScenarioResults = scenarioResults
            };

            Dictionary<Guid, List<TaskResult>> resultsByTask = new Dictionary<Guid, List<TaskResult>>();

            foreach (ScenarioResult result in scenarioResults)
                BuildResultDictionary(result.TaskResultTree, resultsByTask);

            Dictionary<Guid, TaskResultEvaluation> evauationsByTask = resultsByTask.ToDictionary(pair => pair.Key, pair => EvaluateTaskResults(pair.Value));

            scenarioResultEvaluation.TaskResultEvaluation = BuildTaskResultEvaluation(scenarioResults.First().TaskResultTree, evauationsByTask);

            return scenarioResultEvaluation;
        }

        /// <summary>
        /// Builds the task result evaluation.
        /// </summary>
        /// <param name="taskResultTreeNode">The task result tree node.</param>
        /// <param name="evaluations">The evauations by task.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private TaskResultEvaluation BuildTaskResultEvaluation(TreeNode<TaskResult> taskResultTreeNode, Dictionary<Guid, TaskResultEvaluation> evaluations)
        {
            TaskResultEvaluation taskResultEvaluation = evaluations[taskResultTreeNode.Value.Task.Id];

            if (taskResultTreeNode.Children.Any())
                ((CompositeTaskResultEvaluation) taskResultEvaluation).TaskResultEvaluations =
                    taskResultTreeNode.Children.Select(n => BuildTaskResultEvaluation(n, evaluations));
            
            return taskResultEvaluation;
        }

        /// <summary>
        /// Builds the result dictionary.
        /// </summary>
        /// <param name="taskResultTree">The task result tree.</param>
        /// <param name="resultsByTask">The results by task.</param>
        private void BuildResultDictionary(TreeNode<TaskResult> taskResultTree, Dictionary<Guid, List<TaskResult>> resultsByTask)
        {
            Guid id = taskResultTree.Value.Task.Id;

            if (resultsByTask.ContainsKey(id))
                resultsByTask[id].Add(taskResultTree.Value);
            else
                resultsByTask.Add(id, new List<TaskResult> { taskResultTree.Value });

            foreach (TreeNode<TaskResult> child in taskResultTree.Children)
                BuildResultDictionary(child, resultsByTask);
        }
    }
}
