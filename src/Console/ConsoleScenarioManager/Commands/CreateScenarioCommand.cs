using CommandLine;

namespace ConsoleScenarioManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ApiCommand" />
    [Verb("create-scenario", HelpText = "Creates a new scenario.")]
    public class CreateScenarioCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Option("name", HelpText = "The name of the scenario.")]
        public string Name { get; set; }

        [Option("procedure-id", HelpText = "The identifier of the procedure this scenario applies to.")]
        public string ProcedureId { get; set; }
    }
}