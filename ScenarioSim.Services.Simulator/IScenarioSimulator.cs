using System;
using System.Collections.Generic;
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
        /// Determines whether the simulator is active.
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// Adds the given complication enactor to the simulator. The enactor will
        /// perform custom logic for the client when a complication occurs.
        /// </summary>
        /// <param name="enactor">The enactor to be added to the simulator.</param>
        void AddEnactor(IComplicationEnactor enactor);

        /// <summary>
        /// Determines if the task with the given name is active.
        /// </summary>
        /// <param name="task">The name of the given task.</param>
        /// <returns>True if the task is active.</returns>
        bool IsTaskActive(string task);

        /// <summary>
        /// Retrieves a the names of all actives tasks in the scenario.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> ActiveTasks();

        /// <summary>
        /// Retrieves the simulation results.
        /// </summary>
        SimulationResult Result { get; }

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
