using System;
using System.Collections.Generic;
using SchemaManagement.Domain.SeedWork;

namespace SchemaManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SchemaManagement.Domain.SeedWork.ValueObject" />
    /// <seealso cref="Schema.Domain.SeedWork.ValueObject" />
    public class ScenarioAsset : ValueObject
    {
        /// <summary>
        /// The asset identifier
        /// </summary>
        /// <value>
        /// The asset identifier.
        /// </value>
        public Guid AssetId { get; private set; }

        /// <summary>
        /// The position
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Vector Position { get; private set; }

        /// <summary>
        /// The rotation
        /// </summary>
        /// <value>
        /// The rotation.
        /// </value>
        public Vector Rotation { get; private set; }

        /// <summary>
        /// The scale
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public Vector Scale { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAsset" /> class.
        /// </summary>
        /// <param name="assetId">The asset identifier.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="scale">The scale.</param>
        public ScenarioAsset(Guid assetId, Vector position, Vector rotation, Vector scale)
        {
            this.AssetId = assetId;
            this.Position = position;
            this.Rotation = rotation;
            this.Scale = scale;
        }

        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.AssetId;
            yield return this.Position;
            yield return this.Rotation;
            yield return this.Scale;
        }
    }
}