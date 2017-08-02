using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace ConsoleSchemaManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.Commands.ApiCommand" />
    [Verb("create-asset", HelpText = "Creates the asset in the given schema.")]
    public class CreateSchemaAssetCommand : ApiCommand
    {
        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        [Option("schema-id", HelpText = "The id of the desired schema", Required = true)]
        public string SchemaId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Option("name", HelpText = "The name of the asset.", Required = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        [Option("tag", HelpText = "The tag to identify the asset.", Required = true)]
        public string Tag { get; set; }
    }
}
