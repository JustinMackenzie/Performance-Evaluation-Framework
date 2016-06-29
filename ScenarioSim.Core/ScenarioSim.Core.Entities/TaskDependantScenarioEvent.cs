using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a complication that is triggered when a task is started or finished.
    /// </summary>
    public class TaskDependantScenarioEvent : ScenarioEvent
    {
        /// <summary>
        /// The task that the complication depends on.
        /// </summary>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Determines if the complication is triggered at the start of a task. 
        /// </summary>
        public bool Entry { get; set; }
    }
}
