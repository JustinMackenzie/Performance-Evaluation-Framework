using CommandLine;

namespace ConsoleTrialSetManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleTrialSetManager.Commands.ApiCommand" />
    public class UpdateTrialSetNameCommand : ApiCommand
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Option("name", HelpText = "The new name to give the trial set.")]
        public string Name { get; set; }
    }
}
