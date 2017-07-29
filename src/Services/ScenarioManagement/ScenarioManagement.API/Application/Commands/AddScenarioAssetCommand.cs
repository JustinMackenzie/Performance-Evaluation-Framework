using System;
using MediatR;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioAsset" />
    public class AddScenarioAssetCommand : IRequest<ScenarioAsset>
    {
        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public VectorDto Position { get; set; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>
        /// The rotation.
        /// </value>
        public VectorDto Rotation { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public VectorDto Scale { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag { get; set; }
    }
}