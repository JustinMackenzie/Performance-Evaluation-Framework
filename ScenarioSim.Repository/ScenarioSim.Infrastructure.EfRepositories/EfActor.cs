using System;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// The view model for actor details.
    /// </summary>
    public class EfActor : EfEntity
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
    }
}