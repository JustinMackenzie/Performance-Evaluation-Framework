using System.Collections.Generic;
using System.Linq;
using ScenarioManagement.Domain.Exceptions;
using ScenarioManagement.Domain.SeedWork;

namespace ScenarioManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Entity" />
    public class Scenario : Entity, IAggregateRoot
    {
        /// <summary>
        /// The scenario assets
        /// </summary>
        private readonly List<ScenarioAsset> _scenarioAssets;

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
        public IReadOnlyList<ScenarioAsset> Assets => this._scenarioAssets.AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="Scenario" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Scenario(string name)
        {
            this.Name = name;
            this._scenarioAssets = new List<ScenarioAsset>();
        }

        /// <summary>
        /// Adds the asset.
        /// </summary>
        /// <param name="tag">The asset identifier.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="scale">The scale.</param>
        public ScenarioAsset AddAsset(string tag, Vector position, Vector rotation, Vector scale)
        {
            ScenarioAsset asset = new ScenarioAsset(tag, position, rotation, scale);
            this._scenarioAssets.Add(asset);
            return asset;
        }

        /// <summary>
        /// Removes the asset.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <exception cref="ScenarioManagementDomainException">There is no asset with the given tag.</exception>
        public void RemoveAsset(string tag)
        {
            ScenarioAsset asset = this._scenarioAssets.FirstOrDefault(a => a.Tag == tag);

            if (asset == null)
            {
                throw new ScenarioManagementDomainException("There is no asset with the given tag.");
            }

            this._scenarioAssets.Remove(asset);
        }
    }
}