using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    /// <summary>
    /// An interface that provides the means to store and retrieve user action entities.
    /// </summary>
    public interface IUserActionRepository
    {
        /// <summary>
        /// Returns all of the user events in the repository.
        /// </summary>
        IEnumerable<UserAction> GetAll();

        /// <summary>
        /// Stores the given user action in the repository.
        /// </summary>
        /// <param name="e"></param>
        void Save(UserAction e);
    }
}
