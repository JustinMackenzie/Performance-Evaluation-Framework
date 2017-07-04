using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    [Verb("create-schema", HelpText = "Creates a schema with the given properties.")]
    public class CreateSchemaCommand : ApiCommand
    {
        [Option("name", HelpText = "The name of the schema.", Required = true)]
        public string Name { get; set; }

        [Option("description", HelpText = "The description of the schema.", Required = true)]
        public string Description { get; set; }
    }
}