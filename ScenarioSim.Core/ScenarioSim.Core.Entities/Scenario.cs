using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Utility;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a scenario that contains a task hierarchy, complications and entities.
    /// </summary>
    public class Scenario : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        public Guid SchemaId { get; set; }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        public virtual Schema Schema { get; set; }

        /// <summary>
        /// Gets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public Task Task => TaskTree?.Value;

        /// <summary>
        /// Gets the task transitions.
        /// </summary>
        /// <value>
        /// The task transitions.
        /// </value>
        public IEnumerable<TaskTransition> TaskTransitions => Schema?.TaskTransitions; 

        /// <summary>
        /// Gets the task tree.
        /// </summary>
        /// <value>
        /// The task tree.
        /// </value>
        public TreeNode<Task> TaskTree
        {
            get
            {
                if (Schema == null)
                    return null;

                TreeNode<Task> node = Schema.TaskTree;        
                node.Traverse(CopyScenarioSpecificTaskValues);
                return node;
            }
        }

        /// <summary>
        /// Gets the scenario events.
        /// </summary>
        /// <value>
        /// The scenario events.
        /// </value>
        public List<ScenarioEvent> ScenarioEvents { get; set; }

        /// <summary>
        /// Gets the scenario assets.
        /// </summary>
        /// <value>
        /// The scenario assets.
        /// </value>
        public List<ScenarioAsset> ScenarioAssets { get; set; }

        /// <summary>
        /// Gets or sets the scenario task definitions.
        /// </summary>
        /// <value>
        /// The scenario task definitions.
        /// </value>
        public List<ScenarioTaskDefinition> ScenarioTaskDefinitions { get; set; }

        /// <summary>
        /// Gets the scenario specific tasks.
        /// </summary>
        /// <value>
        /// The scenario specific tasks.
        /// </value>
        public Dictionary<Guid, TaskValues> ScenarioSpecificTasks => ScenarioTaskDefinitions.ToDictionary(t => t.TaskId, t => t.TaskValues);

        /// <summary>
        /// Copies the scenario specific task values.
        /// </summary>
        /// <param name="task">The task.</param>
        private void CopyScenarioSpecificTaskValues(Task task)
        {
            TaskValues taskValues;

            if (ScenarioSpecificTasks.TryGetValue(task.Id, out taskValues))
                task.TaskValues = taskValues;
        }
    }
}
