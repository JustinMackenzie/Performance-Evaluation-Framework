using System.Xml.Serialization;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents an event that arises during a scenario that causes complications and increases
    /// difficulty of the task.
    /// </summary>
    [XmlInclude(typeof(TaskDependantScenarioEvent))]
    public abstract class ScenarioEvent
    {
        /// <summary>
        /// The identification number of the complication.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the complication.
        /// </summary>
        public string Name { get; set; }
    }
}
