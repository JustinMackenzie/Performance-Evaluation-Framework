using System;
using MediatR;

namespace ScenarioManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest" />
    public class RemoveScenarioCommand : IRequest
    {
        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveScenarioCommand"/> class.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        public RemoveScenarioCommand(Guid scenarioId)
        {
            this.ScenarioId = scenarioId;
        }
    }
}