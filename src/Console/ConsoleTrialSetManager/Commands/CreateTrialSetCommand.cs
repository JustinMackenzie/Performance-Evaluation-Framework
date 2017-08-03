using CommandLine;

namespace ConsoleTrialSetManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ApiCommand" />
    [Verb("create-trial-set", HelpText = "Creates a trial set.")]
    public class CreateTrialSetCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Option("name", HelpText = "The name of the trial set.")]
        public string Name { get; set; }
    }
}