using CommandLine;

namespace ConsoleScenarioManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleScenarioManager.Commands.ApiCommand" />
    [Verb("remove-procedure", HelpText = "Removes the specified procedure.")]
    public class RemoveProcedureCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the procedure identifier.
        /// </summary>
        /// <value>
        /// The procedure identifier.
        /// </value>
        [Option("procedure-id", HelpText = "The identifier of the procedure.")]
        public string ProcedureId { get; set; }
    }
}