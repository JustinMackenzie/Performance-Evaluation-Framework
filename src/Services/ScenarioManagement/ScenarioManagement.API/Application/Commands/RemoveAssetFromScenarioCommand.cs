using System;
using MediatR;

namespace ScenarioManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest" />
    public class RemoveAssetFromScenarioCommand : IRequest
    {
        /// <summary>
        /// Gets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveAssetFromScenarioCommand"/> class.
        /// </summary>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="tag">The tag.</param>
        public RemoveAssetFromScenarioCommand(Guid scenarioId, string tag)
        {
            this.ScenarioId = scenarioId;
            this.Tag = tag;
        }
    }
}