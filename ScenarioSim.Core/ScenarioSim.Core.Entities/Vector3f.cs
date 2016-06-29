using System;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// This structure represents a three dimensional vector that holds
    /// floating point precision values.
    /// </summary>
    public class Vector3f
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
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Returns the magnitude of the vector.
        /// </summary>
        public float Magnitude => (float)Math.Sqrt(X * X + Y * Y + Z * Z);

        /// <summary>
        /// Determines the dot product of two given vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The dot product of the two vectors.</returns>
        public static float Dot(Vector3f a, Vector3f b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        /// <summary>
        /// Determines the angle between two given vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The angle between the two vectors.</returns>
        public static float AngleBetween(Vector3f a, Vector3f b)
        {
            return (float)(Math.Acos(Dot(a, b) / (a.Magnitude * b.Magnitude)) * 180/Math.PI);
        }

        /// <summary>
        /// Determines the euclidean distance between two vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The euclidean distance between the two vectors.</returns>
        public static float DistanceBetween(Vector3f a, Vector3f b)
        {
            return (float)Math.Sqrt(
                Math.Pow(a.X - b.X, 2) +
                Math.Pow(a.Y - b.Y, 2) +
                Math.Pow(a.Z - b.Z, 2));
        }

        /// <summary>
        /// Performs vector addition between two vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>A vector that is the sum of the two vectors.</returns>
        public static Vector3f operator +(Vector3f a, Vector3f b)
        {
            return new Vector3f(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Performs vector subtraction between two vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>A vector that is the difference of the two vectors.</returns>
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
            return $"[{X} {Y} {Z}]";
        }
    }
}
