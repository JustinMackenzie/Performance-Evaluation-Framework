using CommandLine;

namespace ConsoleScenarioManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleScenarioManager.Commands.ApiCommand" />
    [Verb("view-all", HelpText = "Retrieves information for all scenarios.")]
    public class ViewAllScenariosCommand : ApiCommand
    {
    }
}