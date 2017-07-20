using System.Collections.Generic;
using TrialSetManagement.Domain.SeedWork;

namespace TrialSetManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ValueObject" />
    public class Vector : ValueObject
    {
        /// <summary>
        /// The x
        /// </summary>
        private float _x;
        /// <summary>
        /// The y
        /// </summary>
        private float _y;
        /// <summary>
        /// The z
        /// </summary>
        private float _z;

        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public float X => this._x;

        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public float Y => this._y;

        /// <summary>
        /// Gets the z.
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        public float Z => this._z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector" /> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        public Vector(float x, float y, float z)
        {
            this._x = x;
            this._y = y;
            this._z = z;
        }

        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this._x;
            yield return this._y;
            yield return this._z;
        }
    }
}
