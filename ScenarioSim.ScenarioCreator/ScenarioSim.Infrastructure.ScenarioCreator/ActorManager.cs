using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.Infrastructure.ScenarioCreator
{
    /// <summary>
    /// Implementation of the actor manager service.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.ScenarioCreator.IActorManager" />
    public class ActorManager : IActorManager
    {
        private readonly ILogger logger;
        private readonly IActorRepository repository;

        public ActorManager(ILogger logger, IActorRepository repository)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.logger = logger;
            this.repository = repository;
        }

        /// <summary>
        /// Gets all actors.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Actor> GetAllActors()
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
        /// Gets the actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Actor GetActor(Guid id)
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
        /// Creates the actor.
        /// </summary>
        /// <param name="actor">The actor.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void CreateActor(Actor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            try
            {
                repository.Save(actor);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="actor">The actor.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void UpdateActor(Guid id, Actor actor)
        {
            try
            {
                Actor a = GetActor(id);

                a.Name = actor.Name;
                a.Description = actor.Description;

                repository.Save(a);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Removes the actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveActor(Guid id)
        {
            try
            {
                Actor actor = GetActor(id);
                repository.Remove(actor);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }
    }
}
