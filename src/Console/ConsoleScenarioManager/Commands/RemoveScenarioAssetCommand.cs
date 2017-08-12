using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace ConsoleScenarioManager.Commands
{
    [Verb("remove-asset", HelpText = "Removes the asset with the given tag from the scenario.")]
    public class RemoveScenarioAssetCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        [Option("scenarioId", HelpText = "The identifier of the scenario to remove the asset from.")]
        public string ScenarioId { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        [Option("tag", HelpText = "The tag of the asset to remove.")]
        public string Tag { get; set; }

        [Option("procedure-id", HelpText = "The identifier of the procedure this scenario applies to.")]
        public string ProcedureId { get; set; }
    }
}
