using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    /// <summary>
    /// Represents an abstraction of a state chart event that triggers
    /// state transitions.
    /// </summary>
    public interface IStateChartEvent
    {
        /// <summary>
        /// The name of the state chart event.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The identification number of the state chart event.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// The timestamp that represents when this event arose.
        /// </summary>
        DateTime Timestamp { get; set; }
    }
}
