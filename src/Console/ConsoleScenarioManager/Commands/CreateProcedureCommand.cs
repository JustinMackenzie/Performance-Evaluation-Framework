using CommandLine;

namespace ConsoleScenarioManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleScenarioManager.Commands.ApiCommand" />
    [Verb("create-procedure", HelpText = "Creates the procedure.")]
    public class CreateProcedureCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Option("name", HelpText = "The name of the procedure.")]
        public string Name { get; set; }
    }
}