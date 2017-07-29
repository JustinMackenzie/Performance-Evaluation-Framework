using System.Collections.Generic;
using ScenarioManagement.Domain.SeedWork;

namespace ScenarioManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ValueObject" />
    public class ScenarioAsset : ValueObject
    {
        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag { get; private set; }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Vector Position { get; private set; }

        /// <summary>
        /// Gets the rotation.
        /// </summary>
        /// <value>
        /// The rotation.
        /// </value>
        public Vector Rotation { get; private set; }

        /// <summary>
        /// Gets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public Vector Scale { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAsset" /> class.
        /// </summary>
        /// <param name="tag">The asset identifier.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="scale">The scale.</param>
        public ScenarioAsset(string tag, Vector position, Vector rotation, Vector scale)
        {
            this.Tag = tag;
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
            yield return this.Tag;
            yield return this.Position;
            yield return this.Rotation;
            yield return this.Scale;
        }
    }
}