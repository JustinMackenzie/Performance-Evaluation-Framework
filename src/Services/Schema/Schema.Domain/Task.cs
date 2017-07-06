using System;
using Schema.Domain.SeedWork;

namespace Schema.Domain
{
    /// <summary>
    /// Represents a task to be performed in a schema.
    /// </summary>
    /// <seealso cref="Schema.Domain.Entity" />
    public class Task : Entity
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
        public string Name => this._name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Task(string name)
        {
            this._name = name;
        }
    }
}
