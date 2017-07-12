using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.Commands.ApiCommand" />
    [Verb("create-schema", HelpText = "Creates a schema with the given properties.")]
    public class CreateSchemaCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Option("name", HelpText = "The name of the schema.", Required = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Option("description", HelpText = "The description of the schema.", Required = true)]
        public string Description { get; set; }
    }
}