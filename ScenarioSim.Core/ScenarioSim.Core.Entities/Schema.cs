using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a plan or abstract scenario.
    /// </summary>
    public class Schema
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// The task to be performed in this scenario.
        /// </summary>
        public Task Task { get; set; }

        /// <summary>
        /// Gets the task tree.
        /// </summary>
        /// <value>
        /// The task tree.
        /// </value>
        public TreeNode<Task> TaskTree => Task.GetTaskTreeNode();

        /// <summary>
        /// Gets or sets the actors.
        /// </summary>
        /// <value>
        /// The actors.
        /// </value>
        public List<Actor> Actors { get; set; } 
    }
}
