using System;

namespace TrialManagement.Domain.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class TrialManagementDomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialManagementDomainException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TrialManagementDomainException(string message)
            : base(message)
        {
        }
    }
}