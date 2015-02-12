using System;

namespace ScenarioSim.Core
{
    /// <summary>
    /// This structure represents a three dimensional vector that holds
    /// floating point precision numbers.
    /// </summary>
    public struct Vector3f
    {
        /// <summary>
        /// The X component of the vector.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// The Y component of the vector.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// The Z component of the vector.
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// The constructor that takes in three floating point values.
        /// </summary>
        /// <param name="x">The value to be assigned to the X component of the vector.</param>
        /// <param name="y">The value to be assigned to the Y component of the vector.</param>
        /// <param name="z">The value to be assigned to the Z component of the vector.</param>
        public Vector3f(float x, float y, float z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public static float Dot(Vector3f a, Vector3f b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static float AngleBetween(Vector3f a, Vector3f b)
        {
            return (float)Math.Acos(Dot(a, b) / (a.Magnitude * b.Magnitude));
        }

        public static float DistanceBetween(Vector3f a, Vector3f b)
        {
            return (float)Math.Sqrt(
                Math.Pow(a.X - b.X, 2) +
                Math.Pow(a.Y - b.Y, 2) +
                Math.Pow(a.Z - b.Z, 2));
        }

        public static Vector3f operator +(Vector3f a, Vector3f b)
        {
            return new Vector3f(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3f operator -(Vector3f a, Vector3f b)
        {
            return new Vector3f(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Displays the information of the vector in a string.
        /// </summary>
        /// <returns>A string representation of the vector.</returns>
        public override string ToString()
        {
            return string.Format("[{0} {1} {2}]", X, Y, Z);
        }
    }
}
