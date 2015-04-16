using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    /// <summary>
    /// An interface that provides the means to store and retrieve scenario event entities.
    /// </summary>
    public interface IScenarioEventRepository
    {
        /// <summary>
        /// Returns all of the scenario events in the repository.
        /// </summary>
        ScenarioEventCollection Events { get; }

        /// <summary>
        /// Stores the given scenario event in the repository.
        /// </summary>
        /// <param name="e"></param>
        void Save(ScenarioEvent e);
    }
}
