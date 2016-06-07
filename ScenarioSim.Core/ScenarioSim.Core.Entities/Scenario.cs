using System.Collections.Generic;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a scenario that contains a task hierarchy, complications and entities.
    /// </summary>
    public class Scenario
    {
        /// <summary>
        /// The name of the scenario.
        /// </summary>
        public string Name { get; set; }

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
        public TreeNode<Task> Task{ get; set; }

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
        /// Initializes a new scenario object.
        /// </summary>
        public Scenario()
        {
            Complications = new List<ScenarioEvent>();
            TaskTransitions = new List<TaskTransition>();
            Entities = new List<Entity>();
        }
    }
}
