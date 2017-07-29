using System;

namespace TrialSetManagement.Domain.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class TrialSetManagementDomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSetManagementDomainException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TrialSetManagementDomainException(string message)
            : base(message)
        {
        }
    }
}