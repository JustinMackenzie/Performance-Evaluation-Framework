namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents an item that can be placed into scenarios.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.Entity" />
    public class Asset : Entity
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