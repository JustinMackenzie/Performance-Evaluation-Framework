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
    }
}