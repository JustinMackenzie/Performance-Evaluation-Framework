using System.Collections.Generic;
using ScenarioSim.Performance.Entities;

namespace ScenarioSim.Performance.Repositories
{
    /// <summary>
    /// An interface that provides the means to store and retrieve user action entities.
    /// </summary>
    public interface IUserActionRepository
    {
        /// <summary>
        /// Returns all of the user events in the repository.
        /// </summary>
        IEnumerable<PerformerAction> GetAll();

        /// <summary>
        /// Stores the given user action in the repository.
        /// </summary>
        /// <param name="e"></param>
        void Save(PerformerAction e);
    }
}
