using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.Commands.ApiCommand" />
    [Verb("create-scenario", HelpText = "Creates a scenario for the given schema.")]
    public class CreateScenarioCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Option("name", HelpText = "The name of the scenario.", Required = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        [Option("schema-id", HelpText = "The identifier of the schema.", Required = true)]
        public string SchemaId { get; set; }
    }
}
