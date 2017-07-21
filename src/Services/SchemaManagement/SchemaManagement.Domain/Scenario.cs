using System;
using System.Collections.Generic;
using SchemaManagement.Domain.SeedWork;

namespace SchemaManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Schema.Domain.Entity" />
    public class Scenario : Entity
    {
        /// <summary>
        /// The scenario assets
        /// </summary>
        private List<ScenarioAsset> _scenarioAssets;

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
        /// Initializes a new instance of the <see cref="Scenario"/> class.
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
        /// <param name="assetId">The asset identifier.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="scale">The scale.</param>
        public ScenarioAsset AddAsset(Guid assetId, Vector position, Vector rotation, Vector scale)
        {
            ScenarioAsset asset = new ScenarioAsset(assetId, position, rotation, scale);
            this._scenarioAssets.Add(asset);
            return asset;
        }
    }
}