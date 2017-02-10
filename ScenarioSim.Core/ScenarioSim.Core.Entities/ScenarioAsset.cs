using System;
using ScenarioSim.Utility;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a phyiscal entity in the scenario.
    /// </summary>
    public class ScenarioAsset : Entity
    {
        /// <summary>
        /// The Transform of the entity.
        /// </summary>
        public Transform Transform { get; set; }

        /// <summary>
        /// Gets or sets the asset identifier.
        /// </summary>
        /// <value>
        /// The asset identifier.
        /// </value>
        public Guid AssetId { get; set; }

        /// <summary>
        /// Gets or sets the asset.
        /// </summary>
        /// <value>
        /// The asset.
        /// </value>
        public Asset Asset { get; set; }
    }
}
