using System.Collections.Generic;
using ScenarioManagement.Domain.SeedWork;

namespace ScenarioManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioManagement.Domain.SeedWork.Entity" />
    /// <seealso cref="ScenarioManagement.Domain.SeedWork.IAggregateRoot" />
    public class Scenario : Entity, IAggregateRoot
    {
        /// <summary>
        /// The assets
        /// </summary>
        private List<Asset> _assets;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public IReadOnlyList<Asset> Assets => this._assets.AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="Scenario" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Scenario(string name)
        {
            this.Name = name;
            this._assets = new List<Asset>();
        }
    }
}
