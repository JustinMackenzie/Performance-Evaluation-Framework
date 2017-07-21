using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    [Verb("set-scenario-asset", HelpText = "Sets the given asset in the given scenario with the given transform.")]
    public class SetScenarioAssetCommand : ApiCommand
    {
        [Option("schema-id", HelpText = "The id of the desired schema.", Required = true)]
        public string SchemaId { get; set; }

        [Option("scenario-id", HelpText = "The id of the desired scenario.", Required = true)]
        public string ScenarioId { get; set; }

        [Option("asset-id", HelpText = "The id of the desired asset.", Required = true)]
        public string AssetId { get; set; }

        [Option("position", HelpText = "The position vector of the asset.", Required = true, Separator = ',')]
        public IEnumerable<string> Position { get; set; }

        [Option("rotation", HelpText = "The rotation vector of the asset.", Required = true, Separator = ',')]
        public IEnumerable<string> Rotation { get; set; }

        [Option("scale", HelpText = "The scaling vector of the asset.", Required = true, Separator = ',')]
        public IEnumerable<string> Scale { get; set; }
    }
}
