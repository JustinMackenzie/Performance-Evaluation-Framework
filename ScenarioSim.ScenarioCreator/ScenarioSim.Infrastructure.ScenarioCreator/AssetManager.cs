using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.Infrastructure.ScenarioCreator
{
    /// <summary>
    /// Implementation of the asset manager service.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.ScenarioCreator.IAssetManager" />
    public class AssetManager : IAssetManager
    {
        private readonly ILogger logger;
        private readonly IAssetRepository repository;

        public AssetManager(ILogger logger, IAssetRepository repository)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.logger = logger;
            this.repository = repository;
        }

        /// <summary>
        /// Gets all assets.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Asset> GetAllAssets()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the asset.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Asset GetAsset(Guid id)
        {
            try
            {
                return repository.Get(id);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates the asset.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void CreateAsset(Asset asset)
        {
            if (asset == null)
                throw new ArgumentNullException(nameof(asset));

            try
            {
                repository.Save(asset);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the asset.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="asset">The asset.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void UpdateAsset(Guid id, Asset asset)
        {
            try
            {
                Asset a = GetAsset(id);

                a.Name = asset.Name;
                a.Description = asset.Description;

                repository.Save(a);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes the asset.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void DeleteAsset(Guid id)
        {
            try
            {
                Asset asset = GetAsset(id);
                repository.Remove(asset);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }
    }
}
