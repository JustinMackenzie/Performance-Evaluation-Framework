using System.Collections.Generic;
using SchemaManagement.Domain.SeedWork;

namespace SchemaManagement.Domain
{
    /// <summary>
    /// Represents a possible event that can occur within a schwm
    /// </summary>
    /// <seealso cref="Schema.Domain.ValueObject" />
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
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Event(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.Name;
        }
    }
}
