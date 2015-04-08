﻿using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    public interface IScenarioSimulator
    {
        /// <summary>
        /// Starts the simulator. This must be called before submitting an event.
        /// </summary>
        void Start();

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

        IEnumerable<string> ActiveTasks();

        SimulationResult Result { get; }

        void AddComponent(ISimulationComponent component);

        ISimulationComponent GetComponent(Type type);
    }
}
