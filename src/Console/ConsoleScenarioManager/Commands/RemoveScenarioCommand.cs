using CommandLine;

namespace ConsoleScenarioManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleScenarioManager.Commands.ApiCommand" />
    [Verb("remove-scenario", HelpText = "Removes the specified scenario.")]
    public class RemoveScenarioCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        [Option("scenario-id", HelpText = "The identifier of the scenario.")]
        public string ScenarioId { get; set; }

        [Option("procedure-id", HelpText = "The identifier of the procedure this scenario applies to.")]
        public string ProcedureId { get; set; }
    }
}