using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.ScenarioCreator
{
    /// <summary>
    /// A service used to manage asset entities.
    /// </summary>
    public interface IAssetManager
    {
        /// <summary>
        /// Gets all the assets.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Asset> GetAllAssets();

        /// <summary>
        /// Gets the asset.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Asset GetAsset(Guid id);

        /// <summary>
        /// Creates the asset.
        /// </summary>
        /// <param name="asset">The asset.</param>
        void CreateAsset(Asset asset);

        /// <summary>
        /// Updates the asset.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="asset">The asset.</param>
        void UpdateAsset(Guid id, Asset asset);

        /// <summary>
        /// Deletes the asset.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteAsset(Guid id);
    }
}
