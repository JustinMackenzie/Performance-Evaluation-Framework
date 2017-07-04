using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    public abstract class ApiCommand : ICommand
    {
        [Option("server", HelpText = "The URL of the API server.", Required = true)]
        public string ServerUrl { get; set; }
    }
}