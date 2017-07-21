using System;
using BuildingBlocks.EventBus.Events;
using SchemaManagement.API.Application.Commands;

namespace SchemaManagement.API.IntegrationEvents.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Events.IntegrationEvent" />
    public class ScenarioAssetSetIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        public Guid SchemaId { get; private set; }

        /// <summary>
        /// Gets or sets the scenario identifier.
        /// </summary>
        /// <value>
        /// The scenario identifier.
        /// </value>
        public Guid ScenarioId { get; private set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public VectorDto Position { get; private set; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>
        /// The rotation.
        /// </value>
        public VectorDto Rotation { get; private set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public VectorDto Scale { get; private set; }

        /// <summary>
        /// Gets or sets the asset identifier.
        /// </summary>
        /// <value>
        /// The asset identifier.
        /// </value>
        public Guid AssetId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAssetSetIntegrationEvent"/> class.
        /// </summary>
        /// <param name="schemaId">The schema identifier.</param>
        /// <param name="scenarioId">The scenario identifier.</param>
        /// <param name="assetId">The asset identifier.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="scale">The scale.</param>
        public ScenarioAssetSetIntegrationEvent(Guid schemaId, Guid scenarioId, Guid assetId, VectorDto position,
            VectorDto rotation, VectorDto scale)
        {
            this.SchemaId = schemaId;
            this.ScenarioId = scenarioId;
            this.AssetId = assetId;
            this.Position = position;
            this.Rotation = rotation;
            this.Scale = scale;
        }
    }
}