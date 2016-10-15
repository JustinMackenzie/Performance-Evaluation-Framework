using System.Collections.Generic;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// The view model for schema details.
    /// </summary>
    public class EfSchema : EfEntity
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
        /// Gets or sets the task transitions.
        /// </summary>
        /// <value>
        /// The task transitions.
        /// </value>
        public List<EfTaskTransition> TaskTransitions { get; set; }

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public List<EfTask> Tasks { get; set; }
    }
}