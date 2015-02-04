
namespace ScenarioSim.Core
{
    /// <summary>
    /// A task transition represents a transition from one task to another
    /// in a flow chart. It contains the source task, destination task and the 
    /// identification of the event that triggers this transition in the state chart
    /// representation.
    /// </summary>
    public class TaskTransition
    {
        /// <summary>
        /// The name of the source task in the transition.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The name of the destination task in the transition.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// The identification of the event that triggers this transition in
        /// the state chart representation.
        /// </summary>
        public int EventId { get; set; }
    }
}
