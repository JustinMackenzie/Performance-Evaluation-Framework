using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.ScenarioCreator
{
    /// <summary>
    /// Interface used for managing actors.
    /// </summary>
    public interface IActorManager
    {
        /// <summary>
        /// Gets all actors.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Actor> GetAllActors();

        /// <summary>
        /// Gets the actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Actor GetActor(Guid id);

        /// <summary>
        /// Creates the actor.
        /// </summary>
        /// <param name="actor">The actor.</param>
        void CreateActor(Actor actor);

        /// <summary>
        /// Updates the actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="actor">The actor.</param>
        void UpdateActor(Guid id, Actor actor);

        /// <summary>
        /// Removes the actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void RemoveActor(Guid id);
    }
}
