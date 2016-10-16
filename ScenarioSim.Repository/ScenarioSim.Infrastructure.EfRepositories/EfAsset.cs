using System;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// The view model for asset details.
    /// </summary>
    public class EfAsset : EfEntity
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