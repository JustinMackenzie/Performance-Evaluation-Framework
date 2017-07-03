using System.Collections.Generic;
using Schema.Domain.SeedWork;

namespace Schema.Domain
{
    /// <summary>
    /// Represents a possible event that can occur within a schwm
    /// </summary>
    /// <seealso cref="Schema.Domain.ValueObject" />
    public class Event : ValueObject
    {
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Event(string name)
        {
            this._name = name;
        }

        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this._name;
        }
    }
}
