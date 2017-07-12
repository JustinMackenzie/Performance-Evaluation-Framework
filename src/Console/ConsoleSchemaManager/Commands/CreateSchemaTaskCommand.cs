using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    [Verb("create-task", HelpText = "Creates a task in the given schema.")]
    public class CreateSchemaTaskCommand : ApiCommand
    {
        [Option("name", HelpText = "The name of the task.", Required = true)]
        public string Name { get; set; }

        [Option("schema-id", HelpText = "The identifier of the schema.", Required = true)]
        public string SchemaId { get; set; }
    }
}
