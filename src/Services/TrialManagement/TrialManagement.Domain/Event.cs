using System.Collections.Generic;
using System.Dynamic;
using TrialManagement.Domain.SeedWork;

namespace TrialManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Event : ValueObject
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public long Timestamp { get; private set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        public ExpandoObject Properties { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="properties">The properties.</param>
        public Event(string name, long timestamp, dynamic properties)
        {
            this.Name = name;
            this.Timestamp = timestamp;
            this.Properties = properties;
        }

        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.Name;
            yield return this.Timestamp;
            yield return this.Properties;
        }
    }
}