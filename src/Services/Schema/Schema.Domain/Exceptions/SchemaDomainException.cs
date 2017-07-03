using System;

namespace Schema.Domain.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class SchemaDomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaDomainException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SchemaDomainException(string message)
            : base(message)
        {
        }
    }
}