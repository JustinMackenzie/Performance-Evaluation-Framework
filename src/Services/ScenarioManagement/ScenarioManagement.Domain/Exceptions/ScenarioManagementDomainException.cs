using System;

namespace ScenarioManagement.Domain.Exceptions
{
    public class ScenarioManagementDomainException : Exception
    {
        public ScenarioManagementDomainException(string message)
            : base(message)
        {
        }
    }
}