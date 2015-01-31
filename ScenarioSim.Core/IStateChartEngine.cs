using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    /// <summary>
    /// Represents an abstraction of a state chart that accepts events
    /// and contains a number of states.
    /// </summary>
    public interface IStateChartEngine
    {
        /// <summary>
        /// Dispatches the given event to the state chart to be processed.
        /// </summary>
        /// <param name="e">The state chart event to be processed.</param>
        void Dispatch(IStateChartEvent e);

        /// <summary>
        /// Determines whether the given state is currently active.
        /// </summary>
        /// <param name="name">The name of the given state.</param>
        /// <returns>True if the given state is active.</returns>
        bool IsStateActive(string name);

        /// <summary>
        /// Retrieves a list of the names of all currently active states.
        /// </summary>
        /// <returns>A list of all active states.</returns>
        List<string> ActiveStates();

        /// <summary>
        /// Starts the state chart.
        /// </summary>
        void Start();

        /// <summary>
        /// Determines whether the state chart is active.
        /// </summary>
        bool IsActive { get; }
    }
}
