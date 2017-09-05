using System;
using BuildingBlocks.EventBus.Events;

namespace Gateway.API.Events.SchemaManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Event" />
    public class AssetCreatedEvent : Event
    {
        /// <summary>
        /// Gets or sets the asset identifier.
        /// </summary>
        /// <value>
        /// The asset identifier.
        /// </value>
        public Guid AssetId { get; private set; }

        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        public Guid SchemaId { get; private set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetCreatedEvent"/> class.
        /// </summary>
        /// <param name="assetId">The asset identifier.</param>
        /// <param name="schemaId">The schema identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="tag">The tag.</param>
        public AssetCreatedEvent(Guid assetId, Guid schemaId, string name, string tag)
        {
            this.AssetId = assetId;
            this.SchemaId = schemaId;
            this.Name = name;
            this.Tag = tag;
        }
    }
}