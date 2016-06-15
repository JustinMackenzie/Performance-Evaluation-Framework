namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a task that will test the user's reaction.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Entities.Task" />
    public class ReactionTask : Task
    {
        /// <summary>
        /// Gets or sets the delay.
        /// </summary>
        /// <value>
        /// The delay of the task.
        /// </value>
        public float Delay { get; set; }

        /// <summary>
        /// Sets the specific values.
        /// </summary>
        /// <param name="specificTask">The specific task.</param>
        public override void SetSpecificValues(Task specificTask)
        {
            base.SetSpecificValues(specificTask);

            ReactionTask reactionTask = specificTask as ReactionTask;

            if (reactionTask == null)
                return;

            Delay = reactionTask.Delay;
        }
    }
}
