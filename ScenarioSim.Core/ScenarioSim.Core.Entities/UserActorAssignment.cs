namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a user-actor assignment, where a user performed as a specific actor in a scenario.
    /// </summary>
    public class UserActorAssignment
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the actor.
        /// </summary>
        /// <value>
        /// The actor.
        /// </value>
        public Actor Actor { get; set; }
    }
}
