using System;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    /// <summary>
    /// Represents the data for a user action event.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class SimulatorEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the user action.
        /// </summary>
        /// <value>
        /// The user action.
        /// </value>
        public UserAction UserAction { get; set; }
    }
}