using System;
using BuildingBlocks.EventBus.Events;
using ScenarioManagement.API.Application.Commands;

namespace ScenarioManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class ScenarioAssetAddedEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets the procedure identifier.
        /// </summary>
        /// <value>
        /// The procedure identifier.
        /// </value>
        public Guid ProcedureId { get; }

        /// <summary>
        /// Gets or sets the scenario identifier.
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
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public VectorDto Position { get; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>
        /// The rotation.
        /// </value>
        public VectorDto Rotation { get; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public VectorDto Scale { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAssetAddedEvent" /> class.
        /// </summary>
        /// <param name="procedureId">The procedure identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="scale">The scale.</param>
        public ScenarioAssetAddedEvent(Guid procedureId, Guid scenarioId, string tag, VectorDto position,
            VectorDto rotation, VectorDto scale)
        {
            this.ProcedureId = procedureId;
            this.ScenarioId = scenarioId;
            this.Tag = tag;
            this.Position = position;
            this.Rotation = rotation;
            this.Scale = scale;
        }
    }
}