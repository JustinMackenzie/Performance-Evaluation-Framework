using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ScenarioSim.Core.Entities;
using ScenarioSim.Server.Models;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.Server.Controllers
{
    /// <summary>
    /// Retrieves and stores assets.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [EnableCors("http://localhost:45723", "*", "*")]
    [Authorize]
    public class AssetController : ApiController
    {
        private readonly IAssetManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public AssetController(IAssetManager manager)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));

            this.manager = manager;
        }

        // GET: api/Asset
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AssetViewModel> Get()
        {
            return
                manager.GetAllAssets()
                    .Select(a => new AssetViewModel { Id = a.Id, Name = a.Name, Description = a.Description });
        }

        // GET: api/Asset/5
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public AssetDetailsViewModel Get(Guid id)
        {
            Asset asset = manager.GetAsset(id);

            return new AssetDetailsViewModel
            {
                Id = asset.Id,
                Name = asset.Name,
                Description = asset.Description
            };
        }

        // POST: api/Asset
        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [Authorize(Roles = "Scenario Author, Administrator")]
        public void Post(CreateAssetViewModel model)
        {
            Asset asset = new Asset
            {
                Name = model.Name,
                Description = model.Description
            };

            manager.CreateAsset(asset);
        }

        // PUT: api/Asset/5
        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        [Authorize(Roles = "Scenario Author, Administrator")]
        public void Put(Guid id, EditAssetViewModel model)
        {
            Asset asset = new Asset
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            manager.UpdateAsset(id, asset);
        }

        // DELETE: api/Asset/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [Authorize(Roles = "Scenario Author, Administrator")]
        public void Delete(Guid id)
        {
            manager.DeleteAsset(id);
        }
    }
}
