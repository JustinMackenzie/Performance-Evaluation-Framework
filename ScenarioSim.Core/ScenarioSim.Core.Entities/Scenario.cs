using System;
using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a scenario that contains a task hierarchy, complications and entities.
    /// </summary>
    public class Scenario
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the scenario.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        public Schema Schema { get; set; }

        /// <summary>
        /// Gets or sets the actors.
        /// </summary>
        /// <value>
        /// The actors performing in this scenario.
        /// </value>
        public List<Actor> Actors { get; set; }

        /// <summary>
        /// The task to be performed in this scenario.
        /// </summary>
        public Task Task => TaskTree.Value;

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
                TreeNode<Task> node = Schema.TaskTree;        
                node.Traverse(CopyScenarioSpecificTask);
                return node;
            }
        }

        /// <summary>
        /// The collection of task transitions.
        /// </summary>
        public List<TaskTransition> TaskTransitions { get; set; }
        
        /// <summary>
        /// The collection of complications that will arise during the scenario.
        /// </summary>
        public List<ScenarioEvent> Complications { get; set; }

        /// <summary>
        /// The collection of entities that are located in the spatial domain of the scenario.
        /// </summary>
        public List<Entity> Entities { get; set; }

        /// <summary>
        /// Gets or sets the scenario specific tasks.
        /// </summary>
        /// <value>
        /// The scenario specific tasks.
        /// </value>
        public Dictionary<Guid, Task> ScenarioSpecificTasks { get; set; } 

        /// <summary>
        /// Initializes a new scenario object.
        /// </summary>
        public Scenario()
        {
            Complications = new List<ScenarioEvent>();
            TaskTransitions = new List<TaskTransition>();
            Entities = new List<Entity>();
            ScenarioSpecificTasks = new Dictionary<Guid, Task>();
        }

        private void CopyScenarioSpecificTask(Task task)
        {
            Task specificTask;

            if (ScenarioSpecificTasks.TryGetValue(task.Id, out specificTask))
                task.SetSpecificValues(specificTask);
        }
    }
}
