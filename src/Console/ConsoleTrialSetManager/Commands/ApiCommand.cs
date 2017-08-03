using CommandLine;
using MediatR;

namespace ConsoleTrialSetManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="int" />
    /// <seealso cref="int" />
    public class ApiCommand : IRequest<int>
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