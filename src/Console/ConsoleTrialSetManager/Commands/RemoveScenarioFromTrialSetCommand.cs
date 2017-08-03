using CommandLine;

namespace ConsoleTrialSetManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ApiCommand" />
    [Verb("remove-scenario", HelpText = "Removes the scenario with the given identifier from the trial set.")]
    public class RemoveScenarioFromTrialSetCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the trial set identifier.
        /// </summary>
        /// <value>
        /// The trial set identifier.
        /// </value>
        [Option("trial-set-id", HelpText = "The identifier of the trial set.")]
        public string TrialSetId { get; set; }

        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        [Option("scenario-id", HelpText = "The identifier of the scenario.")]
        public string ScenarioId { get; set; }
    }
}