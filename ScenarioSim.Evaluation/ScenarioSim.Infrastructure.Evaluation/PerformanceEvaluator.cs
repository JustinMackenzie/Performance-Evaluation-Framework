using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.Infrastructure.Evaluation
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.Evaluation.IPerformanceEvaluator" />
    public class PerformanceEvaluator : IPerformanceEvaluator
    {
        /// <summary>
        /// The task evaluator factory
        /// </summary>
        private readonly ITaskEvaluatorFactory taskEvaluatorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceEvaluator"/> class.
        /// </summary>
        /// <param name="taskEvaluatorFactory">The task evaluator factory.</param>
        public PerformanceEvaluator(ITaskEvaluatorFactory taskEvaluatorFactory)
        {
            this.taskEvaluatorFactory = taskEvaluatorFactory;
        }

        /// <summary>
        /// Gets the performances evaluation.
        /// </summary>
        /// <param name="performances">The performances.</param>
        /// <returns></returns>
        public PerformanceEvaluation GetPerformanceEvaluation(IEnumerable<ScenarioPerformance> performances)
        {
            if (performances == null)
                throw new ArgumentNullException(nameof(performances));

            if (!performances.Any())
                throw new ArgumentException("There must be at least one performance.", nameof(performances));

            PerformanceEvaluation result = new PerformanceEvaluation
            {
                Schema = performances.First().Scenario.Schema,
                ScenarioResults = performances,
                TaskPerformanceEvaluations = new Dictionary<Guid, TaskPerformanceEvaluation>()
            };

            Dictionary<Task, List<TaskPerformance>> results = new Dictionary<Task, List<TaskPerformance>>();

            foreach (ScenarioPerformance scenarioPerformance in performances)
            {
                foreach (KeyValuePair<Guid, TaskPerformance> pair in scenarioPerformance.TaskPerformances)
                {
                    Task task = pair.Value.Task;

                    if (results.ContainsKey(task))
                    {
                        results[task].Add(pair.Value);
                    }
                    else
                    {
                        results.Add(task, new List<TaskPerformance> { pair.Value });
                    }
                }
            }

            foreach (KeyValuePair<Task, List<TaskPerformance>> pair in results)
            {
                ITaskEvaluator evaluator = taskEvaluatorFactory.MakeTaskEvaluator(pair.Key);
                TaskPerformanceEvaluation evaluation = evaluator.EvaluateTaskResults(pair.Value);
                result.TaskPerformanceEvaluations.Add(pair.Key.Id, evaluation);
            }

            return result;
        }
    }
}
