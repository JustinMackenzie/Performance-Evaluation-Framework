using ScenarioManagement.Domain;

namespace Gateway.API.DataTransfer
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorDto
    {
        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public float Y { get; set; }

        /// <summary>
        /// Gets or sets the z.
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        public float Z { get; set; }

        /// <summary>
        /// To the vector.
        /// </summary>
        /// <returns></returns>
        public Vector ToVector()
        {
            return new Vector(this.X, this.Y, this.Z);
        }
    }
}