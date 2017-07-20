using System;

namespace TrialSetManagement.Domain.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ScenarioManagementDomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioManagementDomainException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ScenarioManagementDomainException(string message)
            : base(message)
        {
        }
    }
}