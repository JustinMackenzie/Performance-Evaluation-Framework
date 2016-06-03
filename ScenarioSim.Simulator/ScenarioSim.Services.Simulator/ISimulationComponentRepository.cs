using System;
using System.Collections.Generic;

namespace ScenarioSim.Services.Simulator
{
    /// <summary>
    /// Acts as storage container used for saving and retrieving simulation components.
    /// </summary>
    public interface ISimulationComponentRepository
    {
        /// <summary>
        /// Adds the given component to the repository.
        /// </summary>
        /// <param name="component">The component to store.</param>
        void AddComponent(ISimulationComponent component);

        /// <summary>
        /// Retrieves the component with the desired type from the repository.
        /// </summary>
        /// <param name="type">The type of the component.</param>
        /// <returns>The component with the desired type.</returns>
        ISimulationComponent GetComponent(Type type);

        /// <summary>
        /// Retrieves all components from the repository.
        /// </summary>
        /// <returns>An enumerator of all components in the repository.</returns>
        IEnumerable<ISimulationComponent> GetAllComponents();
    }
}
