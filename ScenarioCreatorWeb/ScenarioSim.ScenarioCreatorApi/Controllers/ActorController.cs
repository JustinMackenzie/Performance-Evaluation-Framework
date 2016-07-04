﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ScenarioSim.Core.Entities;
using ScenarioSim.ScenarioCreatorApi.Models;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.ScenarioCreatorApi.Controllers
{
    /// <summary>
    /// The Api controller that receives all actors related calls.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [EnableCors("http://localhost:45723", "*", "*")]
    public class ActorController : ApiController
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IActorManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActorController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public ActorController(IActorManager manager)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));

            this.manager = manager;
        }

        // GET: api/Actor
        /// <summary>
        /// Gets all actors.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ActorViewModel> Get()
        {
            return manager.GetAllActors().Select(a => new ActorViewModel { Id = a.Id, Name = a.Name, Description = a.Description});
        }

        // GET: api/Actor/5
        /// <summary>
        /// Gets the specified actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActorDetailsViewModel Get(Guid id)
        {
            Actor actor = manager.GetActor(id);

            return new ActorDetailsViewModel
            {
                Id = actor.Id,
                Name = actor.Name,
                Description = actor.Description
            };
        }

        // POST: api/Actor
        /// <summary>
        /// Posts the specified actor.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Post(CreateActorViewModel model)
        {
            Actor actor = new Actor
            {
                Name = model.Name,
                Description = model.Description
            };

            manager.CreateActor(actor);
        }

        // PUT: api/Actor/5
        /// <summary>
        /// Puts the specified actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        public void Put(Guid id, EditActorViewModel model)
        {
            Actor actor = new Actor
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            manager.UpdateActor(id, actor);
        }

        // DELETE: api/Actor/5
        /// <summary>
        /// Deletes the specified actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            manager.RemoveActor(id);
        }
    }
}