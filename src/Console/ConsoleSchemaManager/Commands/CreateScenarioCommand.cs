using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    [Verb("create-scenario", HelpText = "Creates a scenario for the given schema.")]
    public class CreateScenarioCommand : ApiCommand
    {
        [Option("name", HelpText = "The name of the scenario.", Required = true)]
        public string Name { get; set; }

        [Option("schema-id", HelpText = "The identifier of the schema.", Required = true)]
        public string SchemaId { get; set; }
    }
}
