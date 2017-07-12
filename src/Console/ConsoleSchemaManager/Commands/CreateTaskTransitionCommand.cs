using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.Commands.ApiCommand" />
    [Verb("create-task-transition", HelpText = "Creates a task transition for the schema.")]
    public class CreateTaskTransitionCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        /// <value>
        /// The name of the event.
        /// </value>
        [Option("event", HelpText = "The name of the event.", Required = true)]
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the name of the source task.
        /// </summary>
        /// <value>
        /// The name of the source task.
        /// </value>
        [Option("source-task", HelpText = "The name of the source task.", Required = true)]
        public string SourceTaskName { get; set; }

        /// <summary>
        /// Gets or sets the destination task.
        /// </summary>
        /// <value>
        /// The destination task.
        /// </value>
        [Option("destination-task", HelpText = "The name of the destination task.", Required = true)]
        public string DestinationTask { get; set; }

        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        [Option("schema-id", HelpText = "The identifier of the schema.", Required = true)]
        public string SchemaId { get; set; }
    }
}
