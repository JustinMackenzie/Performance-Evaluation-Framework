using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.Commands.ApiCommand" />
    [Verb("create-task", HelpText = "Creates a task in the given schema.")]
    public class CreateSchemaTaskCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Option("name", HelpText = "The name of the task.", Required = true)]
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
