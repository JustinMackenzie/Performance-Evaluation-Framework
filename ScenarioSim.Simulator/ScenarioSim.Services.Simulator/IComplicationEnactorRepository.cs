using System.Collections.Generic;

namespace ScenarioSim.Services.Simulator
{
    /// <summary>
    /// An interface that provides the means to store and retrieve complication enactors.
    /// </summary>
    public interface IComplicationEnactorRepository
    {
        /// <summary>
        /// Retrieves all enactors that are stored by the repository.
        /// </summary>
        IEnumerable<IComplicationEnactor> Enactors { get; }

        /// <summary>
        /// Stores the given enactor into the repository.
        /// </summary>
        /// <param name="enactor">The enactor to be stored.</param>
        void AddEnactor(IComplicationEnactor enactor);

        /// <summary>
        /// Retrieves the enactor with the given identifier.
        /// </summary>
        /// <param name="id">The identifier of the desired enactor.</param>
        /// <returns>The enactor with the given identifier.</returns>
        IComplicationEnactor GetEnactor(int id);

        /// <summary>
        /// Determines if the enactor with the given identifier exists in the repository.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>True if there is an enactor in the repository with the given identifier.</returns>
        bool Contains(int id);
    }
}
