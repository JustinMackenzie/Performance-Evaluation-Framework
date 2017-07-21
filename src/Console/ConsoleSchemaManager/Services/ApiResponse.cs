using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchemaManager.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ApiResponse(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Message;
        }
    }
}
