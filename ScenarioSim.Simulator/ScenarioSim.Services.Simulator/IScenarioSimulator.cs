using System;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    /// <summary>
    /// The scenario simulator provides the means to execute a scenario.
    /// </summary>
    public interface IScenarioSimulator
    {
        /// <summary>
        /// Starts the simulator with the given scenario.
        /// </summary>
        /// <param name="scenario">The scenario to be performed.</param>
        void Start(Scenario scenario);

        /// <summary>
        /// Stops the simulator. This will conclude the scenario execution.
        /// </summary>
        void Stop();

        /// <summary>
        /// Submits the given event to the simulator to be processed.
        /// </summary>
        /// <param name="e">The event to be processed.</param>
        void SubmitSimulatorEvent(ScenarioEvent e);

        /// <summary>
        /// Adds the given complication enactor to the simulator. The enactor will
        /// perform custom logic for the client when a complication occurs.
        /// </summary>
        /// <param name="enactor">The enactor to be added to the simulator.</param>
        void AddEnactor(IComplicationEnactor enactor);

        /// <summary>
        /// Adds the given component to the simulator.
        /// </summary>
        /// <param name="component">The component to add to the simulator.</param>
        void AddComponent(ISimulationComponent component);

        /// <summary>
        /// Retrieves the component of the given type from the simulator.
        /// </summary>
        /// <param name="type">The type of the desired component.</param>
        /// <returns>The component with the desired type.</returns>
        ISimulationComponent GetComponent(Type type);
    }
}
