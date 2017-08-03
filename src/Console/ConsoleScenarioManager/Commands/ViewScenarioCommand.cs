using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace ConsoleScenarioManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleScenarioManager.Commands.ApiCommand" />
    [Verb("view-scenario", HelpText = "Retrieves the information about a specific scenario.")]
    public class ViewScenarioCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        [Option("scenario-id", HelpText = "The identifier of the scenario.")]
        public string ScenarioId { get; set; }
    }
}
