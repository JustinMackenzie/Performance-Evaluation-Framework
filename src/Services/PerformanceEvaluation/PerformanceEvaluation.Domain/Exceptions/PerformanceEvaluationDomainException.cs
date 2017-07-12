using System;

namespace PerformanceEvaluation.Domain.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class PerformanceEvaluationDomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceEvaluationDomainException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PerformanceEvaluationDomainException(string message)
            : base(message)
        {
        }
    }
}