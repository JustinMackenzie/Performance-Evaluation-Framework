using System.Collections.Generic;

namespace ConsoleScenarioManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorDto
    {
        /// <summary>
        /// Gets the vector.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static VectorDto GetVector(IList<string> input)
        {
            return new VectorDto
            {
                X = int.Parse(input[0]),
                Y = int.Parse(input[1]),
                Z = int.Parse(input[2])
            };    
        }

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
    }
}