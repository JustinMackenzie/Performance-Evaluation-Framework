namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// Represents an event parameter.
    /// </summary>
    public class EfEventParameter : EfEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the type of the parameter.
        /// </summary>
        /// <value>
        /// The type of the parameter.
        /// </value>
        public string ParameterType { get; set; }
    }
}