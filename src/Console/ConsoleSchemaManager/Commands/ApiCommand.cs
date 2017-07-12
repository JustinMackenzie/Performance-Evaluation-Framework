using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.Commands.ICommand" />
    public abstract class ApiCommand : ICommand
    {
        /// <summary>
        /// Gets or sets the server URL.
        /// </summary>
        /// <value>
        /// The server URL.
        /// </value>
        [Option("server", HelpText = "The URL of the API server.", Required = true)]
        public string ServerUrl { get; set; }
    }
}