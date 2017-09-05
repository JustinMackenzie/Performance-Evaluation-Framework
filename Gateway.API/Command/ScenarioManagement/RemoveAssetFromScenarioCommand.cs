using System;
using MediatR;

namespace Gateway.API.Command.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest" />
    public class RemoveAssetFromScenarioCommand : IRequest
    {
        /// <summary>
        /// Gets the procedure identifier.
        /// </summary>
        /// <value>
        /// The procedure identifier.
        /// </value>
        public Guid ProcedureId { get; }

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
        /// Initializes a new instance of the <see cref="RemoveAssetFromScenarioCommand" /> class.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="tag">The tag.</param>
        public RemoveAssetFromScenarioCommand(Guid procedureId, Guid scenarioId, string tag)
        {
            this.ProcedureId = procedureId;
            this.ScenarioId = scenarioId;
            this.Tag = tag;
        }
    }
}