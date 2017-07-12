using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    [Verb("create-event", HelpText = "Creates an event within the schema.")]
    public class CreateSchemaEventCommand : ApiCommand
    {
        [Option("name", HelpText = "The name of the event.", Required = true)]
        public string Name { get; set; }

        [Option("schema-id", HelpText = "The identifier of the schema.", Required = true)]
        public string SchemaId { get; set; }
    }
}
