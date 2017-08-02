using System;
using System.Collections.Generic;
using CommandLine;

namespace ConsoleScenarioManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ApiCommand" />
    [Verb("add-asset", HelpText = "Adds an asset to the scenario with the given identifier.")]
    public class AddScenarioAssetCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        [Option("scenario-id", HelpText = "The identifier of the scenario.")]
        public Guid ScenarioId { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        [Option("tag", HelpText = "The tag for the asset.")]
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [Option("position", HelpText = "The position vector of the asset.", Separator = ',')]
        public IList<string> Position { get; set; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>
        /// The rotation.
        /// </value>
        [Option("rotation", HelpText = "The rotation vector of the asset.", Separator = ',')]
        public IList<string> Rotation { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        [Option("scale", HelpText = "The scale vector of the asset.", Separator = ',')]
        public IList<string> Scale { get; set; }
    }
}