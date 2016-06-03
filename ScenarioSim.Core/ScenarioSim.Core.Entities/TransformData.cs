
namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// A structure that represents the geometrical placement of an object. This
    /// includes its position, rotation and scaling.
    /// </summary>
    public struct Transform
    {
        /// <summary>
        /// The position component of the transform.
        /// </summary>
        public Vector3f Position { get; set; }

        /// <summary>
        /// The rotation component of the transform.
        /// </summary>
        public Vector3f Rotation { get; set; }

        /// <summary>
        /// The scaling component of the transform.
        /// </summary>
        public Vector3f Scale { get; set; }

        /// <summary>
        /// A constructor that takes in three vectors to assign to the components.
        /// </summary>
        /// <param name="position">The vector to assign to the position component.</param>
        /// <param name="rotation">The vector to assign to the rotation component.</param>
        /// <param name="scale">The vector to assign to the scale component.</param>
        public Transform(Vector3f position, Vector3f rotation, Vector3f scale)
            : this()
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

        /// <summary>
        /// Gives a string representation fo the transform.
        /// </summary>
        /// <returns>A string representation of the transform.</returns>
        public override string ToString()
        {
            return string.Format("Position:{0}; Rotation:{1}; Scale:{2}", Position, Rotation, Scale);
        }
    }
}
