using System.Dynamic;

namespace TrialManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class EventDto
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public long Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        public ExpandoObject Properties { get; set; }
    }
}