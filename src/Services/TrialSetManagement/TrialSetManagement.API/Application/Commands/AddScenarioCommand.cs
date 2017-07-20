using System;
using MediatR;

namespace TrialSetManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest" />
    public class AddScenarioCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; set; }

        /// <summary>
        /// Gets or sets the trial set identifier.
        /// </summary>
        /// <value>
        /// The trial set identifier.
        /// </value>
        public Guid TrialSetId { get; set; }
    }
}