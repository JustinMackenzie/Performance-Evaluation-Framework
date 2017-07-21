using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    [Verb("create-asset", HelpText = "Creates the asset in the given schema.")]
    public class CreateSchemaAssetCommand : ApiCommand
    {
        [Option("schema-id", HelpText = "The id of the desired schema", Required = true)]
        public string SchemaId { get; set; }

        [Option("name", HelpText = "The name of the asset.", Required = true)]
        public string Name { get; set; }

        [Option("tag", HelpText = "The tag to identify the asset.", Required = true)]
        public string Tag { get; set; }
    }
}
