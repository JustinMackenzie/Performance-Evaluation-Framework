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
        public Guid ScenarioId { get; private set; }

        /// <summary>
        /// Gets the trial set identifier.
        /// </summary>
        /// <value>
        /// The trial set identifier.
        /// </value>
        public Guid TrialSetId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveScenarioCommand" /> class.
        /// </summary>
        /// <param name="trialSetId">The trial set identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        public RemoveScenarioCommand(Guid trialSetId, Guid scenarioId)
        {
            this.TrialSetId = trialSetId;
            this.ScenarioId = scenarioId;
        }
    }
}