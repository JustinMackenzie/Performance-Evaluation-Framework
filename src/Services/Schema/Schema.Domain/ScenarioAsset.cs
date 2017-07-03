using System;
using Schema.Domain.SeedWork;
using System.Collections.Generic;

namespace Schema.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Schema.Domain.SeedWork.ValueObject" />
    public class ScenarioAsset : ValueObject
    {
        /// <summary>
        /// The asset identifier
        /// </summary>
        private Guid _assetId;

        /// <summary>
        /// The position
        /// </summary>
        private Vector _position;

        /// <summary>
        /// The rotation
        /// </summary>
        private Vector _rotation;

        /// <summary>
        /// The scale
        /// </summary>
        private Vector _scale;

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Vector Position => this._position;

        /// <summary>
        /// Gets the rotation.
        /// </summary>
        /// <value>
        /// The rotation.
        /// </value>
        public Vector Rotation => this._rotation;

        /// <summary>
        /// Gets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public Vector Scale => this._scale;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAsset" /> class.
        /// </summary>
        /// <param name="assetId">The asset identifier.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="scale">The scale.</param>
        public ScenarioAsset(Guid assetId, Vector position, Vector rotation, Vector scale)
        {
            this._assetId = assetId;
            this._position = position;
            this._rotation = rotation;
            this._scale = scale;
        }

        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this._assetId;
            yield return this._position;
            yield return this._rotation;
            yield return this._scale;
        }
    }
}